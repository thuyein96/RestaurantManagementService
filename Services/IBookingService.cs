namespace RestaurantManagementService.Services;

public interface IBookingService
{
    Task<List<Booking>> GetAllBookingsAsync();
    Task<Booking?> GetBookingByIdAsync(int id);
    Task<ServiceResponse> UpdateBookingAsync(Booking booking);
    Task<ServiceResponse> DeleteBookingAsync(int id);
    Task<ServiceResponse> CreateBookingAsync(Booking booking);
}