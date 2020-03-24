using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public bool HasSea { get; set; }
        public string Img { get; set; }
    }
}
