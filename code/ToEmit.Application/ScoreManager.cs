using System;
using System.Collections.Generic;
using System.Text;
using ToEmit.Infrastructure;
using System.Linq;
using ToEmit.Domain;

namespace ToEmit.Application
{
    public class ScoreManager : IScoreManager
    {
        private readonly ToEmitDBContext _db;
        public ScoreManager(ToEmitDBContext database)
        {
            _db = database;
        }
        public void add_score(string username, int score)
        {
            _db.Scores.Add(new Domain.Scores { Username = username, Score = score });
            _db.SaveChanges();
        }

        public List<Scores> get_all_scores()
        {
            return _db.Scores.OrderBy(x => x.Score).ToList();
        }

        public List<Scores> get_scores_n_from(int start=0, int amount=25)
        {
            return _db.Scores.Skip(start).Take(amount).OrderBy(x => x.Score).ToList();
        }

        public int get_number_of_rows()
        {
            int number_of_rows = _db.Scores.Count();
            return number_of_rows;
        }

        public int get_score(string username)
        {
            int score = _db.Scores.First(x => x.Username == username).Score;
            return score;
        }

    }
}
