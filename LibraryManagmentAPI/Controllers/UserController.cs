using LibraryManagmentAPI.Interface;
using LibraryManagmentAPI.Models;
using LibraryManagmentAPI.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryManagmentAPI.Controllers
{
    [AllowAnonymous]
    public class UserController : ApiController
    {
        public readonly UserService _user;

        public UserController()
        {
            this._user = new UserService();
        }
        
        [Route("api/User/AddUser")]
        [HttpPost]
        public JsonResponse AddUser(User model)
        {
            return _user.Add(model);
        }
        
        [Route("api/User/UpdateUser")]
        [HttpPost]
        public JsonResponse UpdateUser(User model)
        {
            return _user.Update(model);
        }

        [Route("api/User/FetchAll")]
        [HttpGet]
        public JsonResponse FetchAll()
        {
            return _user.FetchAll();
        }

        [HttpGet]
        [Route("api/User/FetchUserByID")]
        public JsonResponse FetchUserByID(long ID)
        {
            return _user.FetchByID(ID);
        }

        [HttpGet]
        [Route("api/User/DeleteUser")]
        public JsonResponse DeleteUser(long ID)
        {
            return _user.Delete(ID);
        }
    }
}