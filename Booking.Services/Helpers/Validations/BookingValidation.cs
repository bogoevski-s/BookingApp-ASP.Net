namespace Booking.Services.Helpers.Validations
{
    using Booking.DataModels.StorageModels;
    using Booking.Models.Requests;

    public static class BookingValidation
    {
        public static string Validate(List<Booking> resourceBookings, BookingRequest request, int resourceQuantity)
        {
            bool hasBookings = resourceBookings.Any();

            if (request.RequestedQuantity > resourceQuantity)
            {
                return "Requested quantity is greater than resource quantity";
            }

            else if (request.DateFrom > request.DateTo)
            {
                return "Start date should be less than end date";
            }

            else if (hasBookings)
            {
                var bookedResources = resourceBookings.Where(x => request.DateFrom < x.DateFrom && request.DateTo >= x.DateFrom ||
                                                                  request.DateFrom <= x.DateTo && request.DateTo > x.DateTo ||
                                                                  request.DateFrom >= x.DateFrom && request.DateTo <= x.DateTo);

                int bookedResourceQuantity = bookedResources.Sum(x => x.BookedQuantity);

                int availableResourceQuantity = resourceQuantity - bookedResourceQuantity;

                if (request.RequestedQuantity > availableResourceQuantity)
                {
                    return "Requested quantity is not available for this time period";
                }
            }

            Console.WriteLine($"EMAIL SENT TO 'admin@admin.com' FOR CREATED BOOKING WITH ID {request.ResourceId}");
            return "Ok";
        }
    }
}
