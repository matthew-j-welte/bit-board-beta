using System.Collections.Generic;
using System.Linq;
using API.Interfaces;
using API.Models.Entities;

namespace API.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public void DeletetUser(User user)
        {
            
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.SingleOrDefault(x => x.UserName == username);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public void InsertUser(User user)
        {
            
        }

        public void UpdateUser(User user)
        {
            
        }
    }
}