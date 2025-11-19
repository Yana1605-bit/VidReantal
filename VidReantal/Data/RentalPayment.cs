namespace VidReantal.Data
{
    public class RentalPayment
    {
        public int Id { get; set; }
        public decimal Total_Rental_Fee { get; set; }
        public decimal Downpayment { get; set; }
        public decimal Balance { get; set; }
        public string Mode_of_Payment { get; set; }
        public DateTime Payment_Date { get; set; }
    }
}
