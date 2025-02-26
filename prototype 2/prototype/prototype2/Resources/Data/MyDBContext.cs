using Microsoft.EntityFrameworkCore;
using prototype2.Resources.Data;




namespace prototype2.Resources.Data
{
    public class MyDBContext : DbContext

    {
 
    public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }
    public DbSet<Category> Categories { get; set; }
        public DbSet<Equipment> EquipmentList { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=LAPTOP-91F1SBEI\\SQLEXPRESS;Database=RentalCompany;User Id=SA;Password=S826agye;Connect Timeout=30;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
