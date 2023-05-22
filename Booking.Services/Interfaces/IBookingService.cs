namespace Booking.Services.Interfaces
{
    using Booking.Models.Requests;

    public interface IBookingService
    {
        Task BookResourceAsync(BookingRequest bookingRequest);
    }
}
