using StudyBuddyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddyRepository.Encription
{
    public interface IAuthRepository
    {
        User RegisterUser(User user, string password);
        User Login(string username, string password);
        bool UserExists(string username);
    }
}
