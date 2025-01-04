using Coursework.Abstraction;
using Coursework.Model;
using Coursework.Service.Interface;
using DocumentFormat.OpenXml.Math;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Service
{
    public class UserService : UserBase, IUserService
    {
        private List<User> _users;

        private String _currentUser;

        public static readonly Guid SeedUserid = Guid.NewGuid();
        public const string SeedUsername = "admin";
        public const string SeedPassword = "password";
        public const int SeedBalance = 350000;
        public const int SeedCurrency = 1;
        public UserService()
        {

            // Load the list of users from the JSON file.

            _users = LoadUsers();
            // If no users are present, add a default admin user and save to the file.
            if (!_users.Any())
            {
                _users.Add(new User { UserId = SeedUserid, UserName = SeedUsername, Password = SeedPassword, Balance = SeedBalance, Currency = Base.Currency.NPR });
                SaveUsers(_users);
            }

        }

        public bool Login(User user)
        {
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
            {
                return false; // Invalid input.
            }

            var existingUser = _users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);

            if (existingUser != null)
            {
                _currentUser = existingUser.UserName;  // Save the email only if the user is found
                return true; // Login successful
            }

            return false; // Login failed
        }

        public void DeleteUser(Guid userId)
        {
            var user = _users.FirstOrDefault(t => t.UserId == userId);
            if (user != null)
            {
                _users.Remove(user);
                SaveUsers(_users); // Save updated list to storage
            }
        }

        public List<User> GetUsers()
        {
            return _users; // Return the list of tags
        }

        public String GetCurrentUser()
        {
            return _currentUser;
        }

        public User GetCurrentUserDetails()
        {
            // Find the user that matches the current username
            var user = _users.FirstOrDefault(u => u.UserName == _currentUser);

            if (user != null)
            {
                return user; // Return the user details if found
            }

            return null; // Return null if no current user found
        }

    }
}
