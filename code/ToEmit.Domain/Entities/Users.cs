using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ToEmit.Domain
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EmailAddres { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }

        public virtual Scores Scores { get; set; }
    }
}
