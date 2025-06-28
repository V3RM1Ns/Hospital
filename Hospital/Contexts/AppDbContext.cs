using Hospital.Models;
using Microsoft.EntityFrameworkCore;
namespace Hospital.Contexts;

public class AppDbContext : DbContext
{
    private string connectionString="Server=localhost,1433;Database=HospitalDB;User Id=sa;Password=Hebib123!;Encrypt=False;";
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
        base.OnConfiguring(optionsBuilder);
    }
}