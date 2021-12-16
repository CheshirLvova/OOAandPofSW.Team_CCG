using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ToEmit.Web.Models
{
    public class ScoresModel
    {
        [Display(Name = "Username")]
        public string username { get; set; }
        [Display(Name ="Score")]
        public int score { get; set; }
    }
}
