namespace Booking.Services.Helpers.Mappers
{
    using Booking.DataModels.StorageModels;
    using Booking.Models.Requests;

    public static class BookingMapper
    {
        public static Booking RequestToStorageBooking(BookingRequest bookingRequest)
        {
            return new Booking
            {
                DateFrom = bookingRequest.DateFrom,
                DateTo = bookingRequest.DateTo,
                BookedQuantity = bookingRequest.RequestedQuantity,
                ResourceId = bookingRequest.ResourceId,
            };
        }
    }
}
