using LibraryManagmentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentAPI.Interface
{
    public interface IUser
    {
        JsonResponse Add(User model);
        JsonResponse Update(User model);
        JsonResponse FetchByID(long ID);
        JsonResponse FetchAll();
        JsonResponse Delete(long ID);
    }
}
