namespace Data.Entities
{
    public class Voucher
    {
        public int VoucherId { get; set; }
        public int TourId { get; set; }
        public virtual Tour Tour { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
