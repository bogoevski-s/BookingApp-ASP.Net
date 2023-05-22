namespace Booking.DataAccess.Interfaces
{
    using Booking.DataModels.StorageModels;

    public interface IBookingRepository
    {
        Task<List<Booking>> GetBookingsByResourceIdAsync(int resourceId);

        Task BookResourceAsync(Booking bookingRequest);
    }
}
