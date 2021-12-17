using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToEmit.Application;
using ToEmit.Web.Models;

namespace ToEmit.Web.Controllers
{
    public class LeaderboardController : Controller
    {
        private readonly IScoreManager _scoreManager;
        private readonly ILogger<LeaderboardController> _logger;
        public LeaderboardController(ILogger<LeaderboardController> logger,IScoreManager scoreManager)
        {
            _scoreManager = scoreManager;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var scores = _scoreManager.get_all_scores();
            List<ScoresModel> score_to_display = new List<ScoresModel>();
            foreach (var score in scores)
            {
                score_to_display.Add(
                    new ScoresModel
                    {
                        username = score.Username,
                        score = score.Score
                    });
            }
            
            return View(score_to_display);
        }
    }
}