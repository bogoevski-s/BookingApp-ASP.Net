namespace Booking.DataAccess.Repositories
{
    using Booking.DataAccess.Interfaces;
    using Booking.DataModels.StorageModels;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ResourceRepository : IResourceRepository
    {
        private readonly BookingDbContext _bookingDb;

        public ResourceRepository(BookingDbContext bookingDb)
        {
            _bookingDb = bookingDb;
        }

        public async Task<Resource> GetResourceByIdAsync(int resourceId)
        {
            Resource resource = await _bookingDb.Resources.SingleOrDefaultAsync(x => x.Id == resourceId);

            if(resource == null)
            {
                throw new Exception("Resource not found");
            }

            return resource;
        }

        public async Task<List<Resource>> GetResourcesAsync()
        {
            return await _bookingDb.Resources.ToListAsync();
        }
    }
}
