using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ToEmit.Web.Models
{
    public class LoginModel
    {
        [Display(Name = "Email addres")]
        [DataType(DataType.EmailAddress)]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        public string Password{ get; set; }
    }
}
