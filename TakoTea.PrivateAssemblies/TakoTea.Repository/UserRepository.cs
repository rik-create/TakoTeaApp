using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public static void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public static void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
