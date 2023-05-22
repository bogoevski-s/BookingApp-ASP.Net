namespace Booking.DataAccess
{
    using Booking.DataModels.StorageModels;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection.Metadata.Ecma335;

    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>()
                .HasData(
                    new Resource { Id = 1, Name = "Developers", Quantity = 5 },
                    new Resource { Id = 2, Name = "QA", Quantity = 3 },
                    new Resource { Id = 3, Name = "HR", Quantity = 4 },
                    new Resource { Id = 4, Name = "DevOps", Quantity = 7 },
                    new Resource { Id = 5, Name = "Designer", Quantity = 9 },
                    new Resource { Id = 6, Name = "Managers", Quantity = 4 },
                    new Resource { Id = 7, Name = "Recruiters", Quantity = 1 },
                    new Resource { Id = 8, Name = "System Administrator", Quantity = 1 },
                    new Resource { Id = 9, Name = "Account Executive", Quantity = 8 },
                    new Resource { Id = 10, Name = "Sales", Quantity = 11 },
                    new Resource { Id = 11, Name = "Marketing", Quantity = 6 }
                );
            modelBuilder.Entity<Booking>()
                .HasData(
                    new Booking
                    {
                        Id = 1,
                        DateFrom = DateTime.UtcNow.AddDays(1),
                        DateTo = DateTime.UtcNow.AddDays(2),
                        BookedQuantity = 2,
                        ResourceId = 1
                    },
                    new Booking
                    {
                        Id = 2,
                        DateFrom = DateTime.UtcNow,
                        DateTo = DateTime.UtcNow.AddDays(1),
                        BookedQuantity = 1,
                        ResourceId = 1
                    }
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>()
                .HasMany(x => x.Bookings)
                .WithOne(x => x.Resource)
                .HasForeignKey(x => x.ResourceId);
            Seed(modelBuilder);
        }
    }
}
