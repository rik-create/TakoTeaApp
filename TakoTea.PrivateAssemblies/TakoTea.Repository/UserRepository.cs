using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TakoTea.Models;

namespace TakoTea.Repository
{
    public static class UserRepository
    {
        private static Entities _context;

        public static void Initialize(Entities context)
        {
            _context = context;
        }



        public static List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public static void AddUser(User user)
        {
            _ = _context.Users.Add(user);
            _ = _context.SaveChanges();
        }

        public static void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _ = _context.SaveChanges();
        }

        public static void DeleteUser(int userId)
        {
            User user = _context.Users.Find(userId);
            if (user != null)
            {
                _ = _context.Users.Remove(user);
                _ = _context.SaveChanges();
            }
        }
    }
}
