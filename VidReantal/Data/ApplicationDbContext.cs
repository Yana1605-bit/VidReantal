using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VidReantal.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<CustomersData> CustomersData { get; set; }
        public DbSet<MovieData> MovieData { get; set; }
        public DbSet<RentalData> RentalData { get; set; }
        public DbSet<RentalPayment> RentalPayment { get; set; }
    }
}
