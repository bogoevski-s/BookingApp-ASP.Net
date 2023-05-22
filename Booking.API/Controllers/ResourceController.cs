namespace Booking.API.Controllers
{
    using Booking.Models.DtoModels;
    using Booking.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/resources")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;

        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResourceDto>>> GetResourcesAsync()
        {
            return await _resourceService.GetResourcesAsync();
        }
    }
}
