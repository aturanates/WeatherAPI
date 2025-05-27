using Microsoft.EntityFrameworkCore;

namespace APIWeather.Context
{
    public class WeatherContext : DbContext
    {
        //public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
        //{
        //}
        public DbSet<Entities.City> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=TURANSMART\\SQLEXPRESS;Database=WeatherDB;Integrated Security=True;TrustServerCertificate=True;");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Entities.City>().ToTable("Cities");
        //    modelBuilder.Entity<Entities.City>().HasKey(c => c.CityId);
        //    modelBuilder.Entity<Entities.City>().Property(c => c.CityName).IsRequired().HasMaxLength(100);
        //    modelBuilder.Entity<Entities.City>().Property(c => c.Country).IsRequired().HasMaxLength(50);
        //    modelBuilder.Entity<Entities.City>().Property(c => c.Temperature).HasColumnType("decimal(5,2)");
        //    modelBuilder.Entity<Entities.City>().Property(c => c.WeatherDescription).HasMaxLength(200);
        //}
    }
}
