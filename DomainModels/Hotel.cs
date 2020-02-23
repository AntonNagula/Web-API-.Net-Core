using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Stars { get; set; }
        public bool HasBeach { get; set; }
        public decimal PricePerDay { get; set; }
        public string facilities { get; set; }
        public string Img { get; set; }
    }
}
