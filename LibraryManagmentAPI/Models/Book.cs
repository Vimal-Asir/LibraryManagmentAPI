using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagmentAPI.Models
{
    public class Book
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Aauthor { get; set; }
        public int Category { get; set; }
        public int Price { get; set; }
        public string Publisher { get; set; }
        public string Image { get; set; }
        public long CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; } = true;

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}