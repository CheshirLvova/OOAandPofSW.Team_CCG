using System;
using System.Security.Cryptography;
using ToEmit.Infrastructure;
using System.Linq;

namespace ToEmit.Application
{
    public class AccountManager : IAccountManager
    {
        private ToEmitDBContext _db;

        public AccountManager(ToEmitDBContext dBContext)
        {
            _db = dBContext;
        }
        public bool UserAlreadyExist(string username)
        {
            bool exist = _db.Users.Any(x => x.Username == username);
            return exist;
        }
        public bool EmailAlreadyInUse(string EmailAddres)
        {
            bool inUse = _db.Users.Any(x => x.EmailAddres == EmailAddres);
            return inUse;
        }
        public void AddUser(string username, string emailAddres, string Password)
        {
            string encryptedPassword = Encryptor.CalculateMD5Hash(Password);
            _db.Users.Add(new Domain.Users { Username = username, EmailAddres = emailAddres, Password = encryptedPassword, Type="User" });
            _db.SaveChanges();
        }
        public bool verifyUser(string login, string password)
        {
            bool valid_email = _db.Users.Any(x => x.EmailAddres == login);
            if (valid_email)
            {
                string trupassword = _db.Users.First(x => x.EmailAddres == login).Password.Replace(" ","");
                string encryptedInputPass = Encryptor.CalculateMD5Hash(password);
                bool verification= (trupassword == encryptedInputPass);
                return verification;
            }
            return false;
        }
        public string getRole(string email)
        {
            string role = _db.Users.First(x => x.EmailAddres == email).Type;
            return role;
        }
        public string getUsername(string email)
        {
            string username = _db.Users.First(x => x.EmailAddres == email).Username;
            return username;
        }
    }
}
