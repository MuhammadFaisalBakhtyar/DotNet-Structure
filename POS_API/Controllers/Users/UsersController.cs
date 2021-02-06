using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using POS_API.Models;
using POS_API.IDataRepository.Users;
using POS_API.DataRepository.Users;
using POS_API.APIResponse;

namespace POS_API.Controllers.Users
{
    [RoutePrefix("Api/Users")]  
    public class UsersController : ApiController
    {
        private POS db = new POS();

        private IUsersRepository _userRepository;  

        public UsersController()
        {
            this._userRepository = new UsersRepository(new POS());  

        }

        [HttpGet]
        [Route("GetAllUsers")]
        public APIResponse<User> GetAllUsers()
        {
            try
            {
                APIResponse<User> apiResponse = new APIResponse<User>();
                var users = _userRepository.GetAllUsers();
                apiResponse.DataEnum = users;
                apiResponse.IsSuccess = true;
                return apiResponse;
            }
            catch(Exception ex)
            {
                APIResponse<User> apiResponse = new APIResponse<User>();
                apiResponse.IsSuccess = false;
                apiResponse.ErrorMessage = ex.Message;
                return apiResponse;
            }
        }

        [HttpGet]
        [Route("GetUser/id/{id}")]
        public APIResponse<User> GetUser(int id)
        {
            try
            {
                APIResponse<User> apiResponse = new APIResponse<User>();
                var users = _userRepository.GetUserById(id);
                apiResponse.DataEnum = users;
                apiResponse.IsSuccess = true;
                return apiResponse;
            }
            catch (Exception ex)
            {
                APIResponse<User> apiResponse = new APIResponse<User>();
                apiResponse.IsSuccess = false;
                apiResponse.ErrorMessage = ex.Message;
                return apiResponse;
            }

            //User user = db.Users.Find(id);
            //if (user == null)
            //{
            //    return NotFound();
            //}

            //return Ok(user);
        }


        [HttpPost]
        [Route("Login")]
        public APIResponse<User> Login (User LoginDetail)
        {
            try
            {
                APIResponse<User> apiResponse = new APIResponse<User>();
                var users = _userRepository.Login(LoginDetail);
                apiResponse.DataEnum = users;
                apiResponse.IsSuccess = true;
                return apiResponse;
            }
            catch (Exception ex)
            {
                APIResponse<User> apiResponse = new APIResponse<User>();
                apiResponse.IsSuccess = false;
                apiResponse.ErrorMessage = ex.Message;
                return apiResponse;
            }

            //User user = db.Users.Find(id);
            //if (user == null)
            //{
            //    return NotFound();
            //}

            //return Ok(user);
        }

        [HttpPost]
        [Route("GetUserbyEmail")]
        public APIResponse<User> GetUserByEmail(User EmailDetail)
        {
            try
            {
                APIResponse<User> apiResponse = new APIResponse<User>();
                var users = _userRepository.GetUserByEmail(EmailDetail);
                apiResponse.DataEnum = users;
                apiResponse.IsSuccess = true;
                return apiResponse;
            }
            catch (Exception ex)
            {
                APIResponse<User> apiResponse = new APIResponse<User>();
                apiResponse.IsSuccess = false;
                apiResponse.ErrorMessage = ex.Message;
                return apiResponse;
            }
        }

        [HttpPost]
        [Route("CreateUser")]
        public APIResponse<User> CreateUser(User UserDetail)
        {
            try
            {
                APIResponse<User> apiResponse = new APIResponse<User>();
                var users = _userRepository.CreateUser(UserDetail);
                //apiResponse.DataEnum = users;
                apiResponse.IsSuccess = true;
                return apiResponse;
            }
            catch (Exception ex)
            {
                APIResponse<User> apiResponse = new APIResponse<User>();
                apiResponse.IsSuccess = false;
                apiResponse.ErrorMessage = ex.Message;
                return apiResponse;
            }
        }


        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.ID }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.ID == id) > 0;
        }
    }
}