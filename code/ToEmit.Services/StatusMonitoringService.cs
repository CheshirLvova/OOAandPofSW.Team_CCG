using System;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ToEmit.Services
{
    public class StatusMonitoringService : BackgroundService
    {
        private readonly ILogger<StatusMonitoringService> _logger;
        private  HttpClient client;
        private SmtpClient SmtpClient;
        private MailAddress from;
        private MailAddress to; 
        private bool send;
        public StatusMonitoringService(ILogger<StatusMonitoringService> logger)
        {
            _logger = logger;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            client = new HttpClient();
            SmtpClient = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("3924826c0ee9d5", "8a9e06afb965ce"),
                EnableSsl = true,
            };
            from = new MailAddress("ToEmit@gmail.com", "Status");
            to = new MailAddress("Admin@gamil.com");
            send = false;
            _logger.LogInformation("StatusMonitoringService started");
            return base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var result = await client.GetAsync("https://toemitweb20211217083641.azurewebsites.net/");
                if(!result.IsSuccessStatusCode)
                {
                    MailMessage message = new MailMessage(from, to);
                    message.IsBodyHtml = true;
                    message.Subject = "App does not response";
                    message.Body =
                        $"<h1>Your web application ToEmit does not response!</h1></br>";
                    SmtpClient.Send(message);
                    send = true;
                    _logger.LogCritical("Whe website is down {StatusCode} ", result.StatusCode);
                }
                else
                {
                    //_logger.LogInformation("Website is up");
                    if(send)
                    {
                        MailMessage message = new MailMessage(from, to);
                        message.IsBodyHtml = true;
                        message.Subject = "Froblem fixed";
                        message.Body =
                            $"<h1>Your web application ToEmit works again!</h1></br>";
                        SmtpClient.Send(message);
                        send = false;
                    }
                }
                await Task.Delay(500, stoppingToken);
            }
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            client.Dispose();
            _logger.LogWarning("StatusMonitoringService stopped");
            return base.StopAsync(cancellationToken);
        }
    }
}
