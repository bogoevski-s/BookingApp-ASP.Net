namespace Booking.Services.Services
{
    using Booking.DataAccess.Interfaces;
    using Booking.DataModels.StorageModels;
    using Booking.Models.Requests;
    using Booking.Services.Helpers.Mappers;
    using Booking.Services.Helpers.Validations;
    using Booking.Services.Interfaces;
    using System.Collections.Generic;

    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IResourceRepository _resourceRepository;

        public BookingService(IBookingRepository bookingRepository, IResourceRepository resourceRepository)
        {
            _bookingRepository = bookingRepository;
            _resourceRepository = resourceRepository;
        }

        public async Task BookResourceAsync(BookingRequest bookingRequest)
        {
            Resource resource = await _resourceRepository.GetResourceByIdAsync(bookingRequest.ResourceId);

            List<Booking> resourceBookings = await _bookingRepository.GetBookingsByResourceIdAsync(bookingRequest.ResourceId);

            string validationMessage = BookingValidation.Validate(resourceBookings, bookingRequest, resource.Quantity);

            if (validationMessage != "Ok")
            {
                throw new Exception(validationMessage);
                
            }

            Booking booking = BookingMapper.RequestToStorageBooking(bookingRequest);
            await _bookingRepository.BookResourceAsync(booking);
        }
    }
}
