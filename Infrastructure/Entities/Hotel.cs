using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Hotel
    {
		public int HotelId { get; set; }
		public string Name { get; set; }
		public bool HasBeach { get; set; }
		public string Img { get; set; }
		public int Stars { get; set; }
		public decimal PricePerDay { get; set; }
		public string facilities { get; set; }
		public int CountryId { get; set; }
		public virtual Country Country { get; set; }
		public int CityId { get; set; }
		public virtual City City { get; set; }
		public List<Tour> Tours { get; set; }

	}
}
