using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Tour
    {
        public int TourId { get; set; }
        public string Name { get; set; } 
        public int Quantity { get; set; } 
        public int CountryId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; set; }
        public virtual Country Country { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
        public List<Voucher> Vouchers { get; set; }
        public int NumberOfNights { get; set; }
        public int? PriceTransfer { get; set; }
        public bool HasTransfer { get; set; }
        public int Price { get; set; }
        public int Markup { get; set; }
        public string Img { get; set; }
    }
}
