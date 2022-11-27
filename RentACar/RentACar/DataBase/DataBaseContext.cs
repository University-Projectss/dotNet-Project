using Microsoft.EntityFrameworkCore;
using RentACar.Models;

namespace RentACar.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Client> ClientsTable { get; set; }
        public DbSet<Car> CarsTable { get; set; }
        public DbSet<Employee> EmployeesTable { get; set; }
        public DbSet<Job> JobsTable { get; set; }
        public DbSet<Location> LocationsTable { get; set; }
        public DbSet<Office> OfficesTable { get; set; }
        public DbSet<Rented> RentedTable { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to One
            modelBuilder.Entity<Office>()
                .HasOne(o => o.Location)
                .WithOne(l => l.Office)
                .HasForeignKey<Location>(l => l.OfficeId);

            //One to Many
            modelBuilder.Entity<Job>()
                .HasMany(j => j.Employees)
                .WithOne(e => e.Job);

            //Many to Many
            modelBuilder.Entity<Rented>()
                .HasKey(r => new { r.ClientId, r.CarId });

            modelBuilder.Entity<Rented>()
                .HasOne<Car>(r => r.Car)
                .WithMany(c => c.Rented)
                .HasForeignKey(r => r.CarId);

            modelBuilder.Entity<Rented>()
                .HasOne<Client>(r => r.Client)
                .WithMany(c => c.Rented)
                .HasForeignKey(r => r.ClientId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
