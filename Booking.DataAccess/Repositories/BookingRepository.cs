namespace Booking.DataAccess.Repositories
{
    using Booking.DataAccess.Interfaces;
    using Booking.DataModels.StorageModels;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BookingRepository : IBookingRepository
    {
        private readonly BookingDbContext _bookingDb;

        public BookingRepository(BookingDbContext bookingDb)
        {
            _bookingDb = bookingDb;
        }

        public async Task<List<Booking>> GetBookingsByResourceIdAsync(int resourceId)
        {
            return await _bookingDb.Bookings.Where(x => x.ResourceId == resourceId).ToListAsync();
        }

        public async Task BookResourceAsync(Booking booking)
        {
            await _bookingDb.Bookings.AddAsync(booking);
            _bookingDb.SaveChanges();
        }
    }
}
