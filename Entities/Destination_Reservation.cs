using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project__B_Night.Entities
{
    public class Destination_Reservation
    {
        public IEnumerable<Destination> deger1 { get; set; }
        public IEnumerable<Reservation> deger2 { get; set; }
    }
}