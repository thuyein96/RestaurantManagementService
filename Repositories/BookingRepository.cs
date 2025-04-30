
namespace RestaurantManagementService.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly AppDbContext _context;

    public BookingRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Booking>> GetAllAsync()
    {
        return await _context.Bookings
            .Include(b => b.Customer)
            .Include(b => b.Table)
            .Include(b => b.BookingSlot)
            .ToListAsync();
    }

    public async Task<Booking?> GetByIdAsync(int id)
    {
        return await _context.Bookings
            .Include(b => b.Customer)
            .Include(b => b.Table)
            .Include(b => b.BookingSlot)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<bool> IsSlotTakenAsync(int timeSlotId, int tableId)
    {
        return await _context.Bookings.AnyAsync(b =>
            b.BookingSlotId == timeSlotId && b.TableId == tableId);
    }

    public async Task AddAsync(Booking booking)
    {
        await _context.Bookings.AddAsync(booking);
    }

    public async Task DeleteAsync(Booking booking)
    {
        _context.Bookings.Remove(booking);
    }
    public async Task UpdateAsync(Booking booking)
    {
        _context.Bookings.Update(booking);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}