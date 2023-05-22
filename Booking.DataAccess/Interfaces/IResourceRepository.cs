namespace Booking.DataAccess.Interfaces
{
    using Booking.DataModels.StorageModels;

    public interface IResourceRepository
    {
        Task<List<Resource>> GetResourcesAsync();

        Task<Resource> GetResourceByIdAsync(int resourceId);
    }
}
