using Microsoft.EntityFrameworkCore;

namespace GymManagmentFinalProject.Resources.Data
{
    public class DatabaseConnection : DbContext
    {
        public DbSet<Employees> Employees { get; set; }

        // Change Members to represent the Clients table
        public DbSet<Clients> Clients { get; set; }
        public DbSet<EquipmentList> EquipmentList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=PETERS-SURFACE;Database=gym;User Id=sa;Password=Password123!;Connect Timeout=30;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map the Members entity to the Clients table in the database
            modelBuilder.Entity<Clients>().ToTable("Clients"); // Ensure the table name is Clients

            base.OnModelCreating(modelBuilder);
        }
    }
}
