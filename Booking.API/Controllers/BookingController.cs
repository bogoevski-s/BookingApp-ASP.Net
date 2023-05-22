namespace Booking.API.Controllers
{
    using Booking.Models.Requests;
    using Booking.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task CreateBookingAsync([FromBody] BookingRequest request)
        {
            await _bookingService.BookResourceAsync(bookingRequest: request);
        }
    }
}
