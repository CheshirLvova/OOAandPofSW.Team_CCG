using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ToEmit.Web.Models
{
    public class UserModel
    {
        [Display(Name ="Username")]
        public string UserName { get; set; }
        [Display(Name ="Email Addres")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddres { get; set; }
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "You need to provide long enough password.")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Compare("Password",ErrorMessage ="Your password and confirm password do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
