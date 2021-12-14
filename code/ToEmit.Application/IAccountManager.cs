using System;
using System.Collections.Generic;
using System.Text;

namespace ToEmit.Application
{
    public interface IAccountManager
    {
        public bool UserAlreadyExist(string username);
        public bool EmailAlreadyInUse(string EmailAddres);
        public void AddUser(string username, string emailAddres, string Password);
        public bool verifyUser(string login, string password);
        public string getRole(string email);
        public string getUsername(string email);
    }
}
