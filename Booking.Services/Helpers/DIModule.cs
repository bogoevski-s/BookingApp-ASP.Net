namespace Booking.Services.Helpers
{
    using Booking.DataAccess;
    using Booking.DataAccess.Interfaces;
    using Booking.DataAccess.Repositories;
    using Booking.Services.Interfaces;
    using Booking.Services.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class DIModule
    {
        public static IServiceCollection RegisterRepositories(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BookingDbContext>(x => x.UseSqlServer(connectionString));

            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<IResourceRepository, ResourceRepository>();

            services.AddTransient<IBookingService, BookingService>();
            services.AddTransient<IResourceService, ResourceService>();

            return services;
        }
    }
}
