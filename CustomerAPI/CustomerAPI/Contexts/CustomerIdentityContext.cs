using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Contexts
{
    public class CustomerIdentityContext: IdentityDbContext
    {
        public CustomerIdentityContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            this.Database.EnsureCreated();

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
