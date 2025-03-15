using CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Contexts
{
    public class CustomerContext:DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> dbContextOptions)
            : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Corporate> Corporates { get; set; }
        public DbSet<Address> Addresses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Individual>()
                .Property(I => I.Gender).HasConversion<string>()
                .HasMaxLength(50);
            modelBuilder.Entity<Corporate>()
                .Property(C => C.CompanyType).HasConversion<string>()
                .HasMaxLength(50);
        }
        
    }
}
