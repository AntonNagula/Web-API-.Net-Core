using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class City
    {
        public int CityId { get; set; }
        public string RusName { get; set; }
        public string EngName { get; set; }
        public bool HasSea { get; set; }
        public string Img { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public List<Hotel> Hotels { get; set; }
        public List<Tour> Tours { get; set; }
    }
}
