using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Hotel
    {
        public string HotelId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Stars { get; set; }
        public bool HasBeach { get; set; }
        public string PricePerDay { get; set; }
        public string facilities { get; set; }
        public string Img { get; set; }
        public string CountryId { get; set; }
        public string CityId { get; set; }
    }
}
