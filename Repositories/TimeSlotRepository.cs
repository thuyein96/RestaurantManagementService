namespace RestaurantManagementService.Repositories;

public class TimeSlotRepository : ITimeSlotRepository
{
    private readonly AppDbContext _context;

    public TimeSlotRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TimeSlot>> GetAllAsync()
    {
        return await _context.TimeSlots.ToListAsync();
    }

    public async Task<TimeSlot?> GetByIdAsync(int id)
    {
        return await _context.TimeSlots.FindAsync(id);
    }
    public async Task AddAsync(TimeSlot timeSlot)
    {
        await _context.TimeSlots.AddAsync(timeSlot);
    }
    public async Task DeleteAsync(TimeSlot timeSlot)
    {
        _context.TimeSlots.Remove(timeSlot);
    }
    public async Task UpdateAsync(TimeSlot timeSlot)
    {
        _context.TimeSlots.Update(timeSlot);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}