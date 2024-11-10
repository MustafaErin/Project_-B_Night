using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project__B_Night.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CountrTitle { get; set; }
        public int Popilation { get; set; }
        public int Teritory { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }

    }
}