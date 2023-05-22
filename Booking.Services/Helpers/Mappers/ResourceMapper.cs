namespace Booking.Services.Helpers.Mappers
{
    using Booking.DataModels.StorageModels;
    using Booking.Models.DtoModels;

    public static class ResourceMapper
    {
        public static ResourceDto StorageToResourceDto(Resource resource)
        {
            return new ResourceDto
            {
                Id = resource.Id,
                Name = resource.Name,
                Quantity = resource.Quantity,
            };
        }
    }
}
