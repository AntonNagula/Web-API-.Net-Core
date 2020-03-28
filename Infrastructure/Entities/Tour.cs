namespace Data.Entities
{
    public class Tour
    {
        public int TourId { get; set; }
        public string Name { get; set; } 
        public int Quantity { get; set; } 
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}
