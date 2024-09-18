using Microsoft.EntityFrameworkCore;
using RealEstateCase.Entity.Main;

namespace RealEstateCase.DataAccess.Contexts
{
    public class RealEstateCaseDbContext : DbContext
    {
        public RealEstateCaseDbContext(DbContextOptions<RealEstateCaseDbContext> options): base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           

        }
    }
}
