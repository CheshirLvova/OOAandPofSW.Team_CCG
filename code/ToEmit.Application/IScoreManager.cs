using System;
using System.Collections.Generic;
using System.Text;
using ToEmit.Domain;
using System.Linq;

namespace ToEmit.Application
{
    public interface IScoreManager
    {
        public int get_number_of_rows();
        public void add_score(string username, int score);
        public int get_score(string username);
        public List<Scores> get_all_scores();
        public List<Scores> get_scores_n_from(int amount, int from);
   
    }
}
