namespace RestaurantManagementService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<DTOs.Customer> Customers { get; set; }
    public DbSet<DTOs.Bookings> Bookings { get; set; }
    public DbSet<DTOs.Table> Tables { get; set; }
    public DbSet<DTOs.TimeSlot> TimeSlots { get; set; }
}