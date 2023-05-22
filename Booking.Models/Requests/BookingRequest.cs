namespace Booking.Models.Requests
{
    public class BookingRequest
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int RequestedQuantity { get; set; }
        public int ResourceId { get; set; }
    }
}
