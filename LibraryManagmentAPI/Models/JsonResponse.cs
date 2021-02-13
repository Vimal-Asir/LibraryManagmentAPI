using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagmentAPI.Models
{
    public class JsonResponse
    {
        public string Status { get; set; } = "F";

        public string Message { get; set; }

        public object Data { get; set; }

    }
}