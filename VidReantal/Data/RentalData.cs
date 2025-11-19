namespace VidReantal.Data
{
    public class RentalData
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string MovieTitle { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; } 
        public decimal RentalFee { get; set; }
        public decimal? LateFee { get; set; }
        public decimal? TotalFees { get; set; }
    }
}
