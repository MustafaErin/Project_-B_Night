using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project__B_Night.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }

        [StringLength(100)]
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; } 

    }
}