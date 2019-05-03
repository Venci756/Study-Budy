using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using StudyBuddyModel;

namespace StudyBuddyRepository.Encription
{
    public class PasswordEncription : IAuthRepository
    {
        public User Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public User RegisterUser(User user, string password)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(string username)
        {
            throw new NotImplementedException();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash,out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                passwordSalt = hmac.Key;
            }
        }
    }
}
