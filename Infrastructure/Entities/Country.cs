using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public bool HasSea { get; set; } 
        public string Img { get; set; }
        public List<Hotel> Hotels { get; set; }
        public List<City> Cities { get; set; }
        public List<Tour> Tours { get; set; }
    }
}
