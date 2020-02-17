using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ProjectDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=A_A_Project;Trusted_Connection=true;");
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\A_A_Project;Trusted_Connection=True;");
            //}
            //Persist Security Info=false;MultipleActiveResultSets=True;(localdb)\mssqllocaldb .\SQLEXPRESS
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
