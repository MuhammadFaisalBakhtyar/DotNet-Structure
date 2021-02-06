using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POS_API.IDataRepository.Users;
using POS_API.Models;
using System.Data;
using POS_API.Helper;
using System.Data.Entity.Validation;

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

        public List<User> Login(User LoginDetail)
        {
            EncryptionData encryptData = new EncryptionData();
            LoginDetail.Password = encryptData.encrypt(LoginDetail.Password);
            var LoginUser = _context.Users.Where(a => a.Username == LoginDetail.Username && a.Password == LoginDetail.Password).ToList();
            if(LoginUser.Count > 0)
            {
                LoginUser[0].Password = encryptData.Decrypt(LoginUser[0].Password);
            }
            return LoginUser;
        }


        public List<User> GetUserByEmail(User EmailDetail)
        {
            var userEmail = _context.Users.Where(a => a.Email == EmailDetail.Email).ToList();
            return userEmail;
        }


        public bool CreateUser(User UserDetail)
        {

            EncryptionData encryptData = new EncryptionData();
            UserDetail.Password = encryptData.encrypt(UserDetail.Password);

            _context.Users.Add(UserDetail);
            _context.SaveChanges();

            return true;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}