using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagmentAPI.Models
{
    public class User
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; } = true;

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}