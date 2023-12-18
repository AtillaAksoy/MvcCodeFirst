using Microsoft.EntityFrameworkCore;
using MvcCodeFirst.Models.Entities;

namespace MvcCodeFirst.Models.Context
{
    public class ProjectContext:DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Fluent API

            //UserCustomize
            modelBuilder.Entity<AppUser>().Property(x => x.Username).HasMaxLength(255);
            modelBuilder.Entity<AppUser>().Property(x => x.Email).HasMaxLength(255);
            modelBuilder.Entity<AppUser>().Property(x => x.Firstname).HasMaxLength(255);
            modelBuilder.Entity<AppUser>().Property(x => x.Lastname).HasMaxLength(255);
            modelBuilder.Entity<AppUser>().Property(x => x.Password).HasMaxLength(255);
            modelBuilder.Entity<Product>().Property(x => x.ProductName).HasMaxLength(255);
            modelBuilder.Entity<Product>().Property(x => x.Description).HasMaxLength(255);
            modelBuilder.Entity<Product>().Property(x => x.Category).HasMaxLength(255);

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //ConnectionString


        //    optionsBuilder.UseSqlServer("server=DESKTOP-J4PTH70;database=CodeFirstMVC;uid=sa;pwd=123;TrustServerCertificate=True");
        //    base.OnConfiguring(optionsBuilder);
        //}

    }
}
