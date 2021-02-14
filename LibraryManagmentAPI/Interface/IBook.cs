using LibraryManagmentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentAPI.Interface
{
    public interface IBook
    {
        JsonResponse Add(Book model);
        JsonResponse Update(Book model);
        JsonResponse FetchByID(long ID);
        JsonResponse FetchAll();
        JsonResponse Delete(long ID);
        JsonResponse Login(string userName, string Password);
    }
}
