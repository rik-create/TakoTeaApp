using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakoTea.Models;

namespace Helpers
{
    public static class AuthenticationHelper
    {

        public static string _loggedInUsername = ""; // Variable to store the logged-in username

        public static bool AuthenticateUser(string username, string password)
        {
             var context = new Entities();
            var user = context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return false;
            }

            return true;
        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool IsPasswordValid(string password) 
    {
        // Implement your password validation logic here, e.g.,
        // - Minimum length
        // - Required character types (uppercase, lowercase, digits, symbols)
        // - etc.

        return true; // Or false if the password is invalid
    }

    public static TakoTea.Models.User GetCurrentUser()
        {
             var context = new Entities();
            string username = _loggedInUsername; // Access the logged-in username from the LoginForm

            return context.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}
