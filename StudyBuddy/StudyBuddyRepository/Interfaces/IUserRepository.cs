using StudyBuddyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddyRepository.Interfaces
{
    public interface IUSerRepository
    {
        User Login(string email, string password);
        User CreateUser(User user);
        bool DeleteUser(int uid);
        User UpdateUser(User user);
        User GetUserByEmail(string email);
        List<User> GetAllUsers();
        void UpdatePassword(User user);
        bool UserExists(string email);
    }
}
