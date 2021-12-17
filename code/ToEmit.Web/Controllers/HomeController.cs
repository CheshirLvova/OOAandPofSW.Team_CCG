using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToEmit.Application;
using ToEmit.Models;
using ToEmit.Web.Models;

namespace ToEmit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IScoreManager _scoreManager;
        public HomeController(ILogger<HomeController> logger,IScoreManager scoreManager)
        {
            _scoreManager = scoreManager;
            _logger = logger;
        }
        [Authorize]
        public IActionResult Index()
        {
            List<CardModel> imageNames = new List<CardModel>();
            imageNames.Add(new CardModel { image_name = "Bat.png" });
            imageNames.Add(new CardModel { image_name = "Bones.png" });
            imageNames.Add(new CardModel { image_name = "Cauldron.png" });
            imageNames.Add(new CardModel { image_name = "Dracula.png" });
            imageNames.Add(new CardModel { image_name = "Eye.png" });
            imageNames.Add(new CardModel { image_name = "Ghost.png" });
            imageNames.Add(new CardModel { image_name = "Pumpkin.png" });
            imageNames.Add(new CardModel { image_name = "Skull.png" });
            imageNames.Add(new CardModel { image_name = "Bat.png" });
            imageNames.Add(new CardModel { image_name = "Bones.png" });
            imageNames.Add(new CardModel { image_name = "Cauldron.png" });
            imageNames.Add(new CardModel { image_name = "Dracula.png" });
            imageNames.Add(new CardModel { image_name = "Eye.png" });
            imageNames.Add(new CardModel { image_name = "Ghost.png" });
            imageNames.Add(new CardModel { image_name = "Pumpkin.png" });
            imageNames.Add(new CardModel { image_name = "Skull.png" });
            return View(imageNames);
        }
        [Authorize]
        [HttpPost]
        public IActionResult SaveScore(int score)
        {
            if(_scoreManager.RecordExist(User.Identity.Name))
            {
                int current_score = _scoreManager.get_score(User.Identity.Name);
                if (current_score < score)
                {
                    _scoreManager.add_score(User.Identity.Name, score);
                    _logger.LogInformation("{user} got new highscore: {score}",User.Identity.Name,score);
                }
            }
            else
            {
                _scoreManager.add_score(User.Identity.Name, score);
            }
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogWarning("Error occured \n{details}", HttpContext.TraceIdentifier);
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
