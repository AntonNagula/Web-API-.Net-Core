using Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace Data
{
    public class ProjectDbContext : DbContext
    {
        bool isTest = false;
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }

        public ProjectDbContext()
        {
            isTest = true;
        }
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(isTest)
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-L7IMM92;Initial Catalog=Project;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
                
    }
}
