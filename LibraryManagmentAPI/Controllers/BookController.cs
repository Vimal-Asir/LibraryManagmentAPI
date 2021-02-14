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
    public class BookController : ApiController
    {
        public readonly BookService service;
        public BookController()
        {
            this.service = new BookService();

            //service = book;
        }

        [Route("api/Book/AddBook")]
        [HttpPost]
        public JsonResponse AddBook(Book model)
        {
            return service.Add(model);
        }

        [Route("api/Book/UpdateBook")]
        [HttpPost]
        public JsonResponse UpdateBook(Book model)
        {
            return service.Update(model);
        }

        [Route("api/Book/FetchAll")]
        [HttpGet]
        public JsonResponse FetchAll()
        {
            return service.FetchAll();
        }

        [Route("api/Book/FetchBookByID")]
        [HttpGet]
        public JsonResponse FetchBookByID(long ID)
        {
            return service.FetchByID(ID);
        }

        [Route("api/Book/DeleteBook")]
        [HttpGet]
        public JsonResponse DeleteBook(long ID)
        {
            return service.Delete(ID);
        }

        [Route("api/Book/Login")]
        [HttpGet]
        public JsonResponse Login(string userName,string Password)
        {
            return service.Login(userName,Password);
        }

        [System.Web.Http.Route("Book/Sample")]
        [HttpGet]
        public string sample()
        {
            return "result";
        }
    }
}