using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POS_API.IDataRepository.Users;
using POS_API.Models;  
using System.Data;  

namespace POS_API.DataRepository.Users
{
    public class UsersRepository : IUsersRepository
    {
        private POS _context;
        public UsersRepository(POS _context)  
        {
            this._context = _context;  
        }
        public IEnumerable<User> GetAllUsers()  
        {
            return _context.Users.ToList();  
        }

        public List<User> GetUserById(int id)
        {
            List<User> user = new List<User>();
            User userById = _context.Users.Find(id);
            user.Add(userById);
            return user;

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}