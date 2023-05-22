namespace Booking.Services.Services
{
    using Booking.DataAccess.Interfaces;
    using Booking.DataModels.StorageModels;
    using Booking.Models.DtoModels;
    using Booking.Services.Helpers.Mappers;
    using Booking.Services.Interfaces;
    using System.Collections.Generic;

    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceService;

        public ResourceService(IResourceRepository resourceService)
        {
            _resourceService = resourceService;
        }

        public async Task<List<ResourceDto>> GetResourcesAsync()
        {
            List<Resource> resources = await _resourceService.GetResourcesAsync();

            List<ResourceDto> resourcesDtos = resources.Select(resource => ResourceMapper.StorageToResourceDto(resource)).ToList();

            return resourcesDtos;
        }
    }
}
