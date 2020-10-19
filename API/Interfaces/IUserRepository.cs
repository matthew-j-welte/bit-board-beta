using System;
using System.Collections.Generic;
using API.Models.Entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
         IEnumerable<User> GetUsers();
         User GetUserByUsername(string username);
         void InsertUser(User user);
         void DeletetUser(User user);
         void UpdateUser(User user);
    }
}