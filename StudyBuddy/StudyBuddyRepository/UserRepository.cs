using StudyBuddyModel;
using StudyBuddyRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyBuddyModel.DataBaseContext;
using System.Security.Cryptography;


namespace StudyBuddyRepository
{
    public class UserRepository : IUSerRepository
    {
        private readonly StudyBudyDatabaseDbContex db;
        public UserRepository()
        {
            db = new StudyBudyDatabaseDbContex();
        }

        public User CreateUser(User user)
        {
            if (user != null)
            {
                CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                db.Users.Add(user);
                db.SaveChanges();
            }
            return user;
        }

        public bool DeleteUser(int uid)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == uid);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<User> GetAllUsers()
        {
            var allUsers = db.Users.ToList();
            return allUsers;
        }

        public User GetUserByEmail(string email)
        {
            if (email != null)
            {
                var user = db.Users.FirstOrDefault(u => u.Email == email);
                return user;
            }
            return null;
        }

        public User Login(string email, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
                return null;
            if (!VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
                return null;
            return user;
        }

        public void UpdatePassword(User user)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            db.SaveChanges();
        }

        public User UpdateUser(User user)
        {
            if (user != null)
            {
                var updateUser = db.Users.FirstOrDefault(u => u.Id == user.Id);
                updateUser.Name = user.Name;
                updateUser.Mobile = user.Mobile;
                updateUser.Email = user.Email;
                db.SaveChanges();
            }
            return user;
        }


        #region Private Methods

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;   
                }
            }
            return true;
        }

        #endregion
    }
}
