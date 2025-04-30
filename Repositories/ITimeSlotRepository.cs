namespace RestaurantManagementService.Repositories;

public interface ITimeSlotRepository
{
    Task<IEnumerable<TimeSlot>> GetAllAsync();
    Task<TimeSlot?> GetByIdAsync(int id);
    Task AddAsync(TimeSlot timeSlot);
    Task DeleteAsync(TimeSlot timeSlot);
    Task UpdateAsync(TimeSlot timeSlot);
    Task SaveChangesAsync();
}
