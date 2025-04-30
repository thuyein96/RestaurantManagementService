namespace RestaurantManagementService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Models.Customer> Customers { get; set; }
    public DbSet<Models.Booking> Bookings { get; set; }
    public DbSet<Models.Table> Tables { get; set; }
    public DbSet<Models.TimeSlot> TimeSlots { get; set; }
}