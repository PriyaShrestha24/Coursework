using Coursework.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Service.Interface
{
    public interface IUserService
    {
        bool Login(User user);

        void DeleteUser(Guid userId);

        List<User> GetUsers();

        User GetCurrentUserDetails();
        String GetCurrentUser();

    }
}
