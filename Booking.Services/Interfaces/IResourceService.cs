namespace Booking.Services.Interfaces
{
    using Booking.Models.DtoModels;

    public interface IResourceService
    {
        Task<List<ResourceDto>> GetResourcesAsync();
    }
}
