using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class VoucherAndTourInfo
    {
        public string VoucherId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string TourId { get; set; }
        public string UserId { get; set; }

        public string Name { get; set; }
        public string StartQuantity { get; set; }
        public string EndQuantity { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string EngNameOfCity { get; set; }
        public string Hotel { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string CountryId { get; set; }
        public string CityId { get; set; }
        public string HotelId { get; set; }

        public string NumberOfNights { get; set; }
        public string PriceTransfer { get; set; }
        public string PriceHotel { get; set; }
        public string Price { get; set; }
        public string Markup { get; set; }
        public string Img { get; set; }
        public bool HasTransfer { get; set; }
    }
}
