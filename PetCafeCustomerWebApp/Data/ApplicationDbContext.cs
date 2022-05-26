using Microsoft.EntityFrameworkCore;
using PetCafeCustomerWebApp.Models;

namespace PetCafeCustomerWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Sharing> Sharings { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<VisitTime> VisitTimes { get; set; }

    }
}
