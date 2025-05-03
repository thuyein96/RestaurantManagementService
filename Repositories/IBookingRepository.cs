namespace RestaurantManagementService.Repositories;

public interface IBookingRepository
{
    Task<IEnumerable<Booking>> GetAllAsync();
    Task<Booking?> GetByIdAsync(int id);
    Task<IEnumerable<Booking>> GetByCustomerIdAsync(int customerId);
    Task<bool> IsSlotTakenAsync(int timeSlotId, int tableId);
    Task AddAsync(Booking booking);
    Task DeleteAsync(Booking booking);
    Task UpdateAsync(Booking booking);
    Task SaveChangesAsync();
}