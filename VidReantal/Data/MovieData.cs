namespace VidReantal.Data
{
    public class MovieData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Copies { get; set; }
        public decimal Rating { get; set; } 
        public decimal RentalPrice { get; set; }
        public string AvailabilityStatus { get; set; }
    }
}
