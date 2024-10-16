using Acredita.Share.Entities;
using Microsoft.EntityFrameworkCore;

namespace Acredita.API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<University> Universities {  get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DataContext(DbContextOptions<DataContext>options):base(options)
        { 

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<University>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Major>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Project>().HasIndex(x => x.Name).IsUnique();
        }
    }
}
