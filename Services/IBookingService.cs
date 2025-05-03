namespace RestaurantManagementService.Services;

public interface IBookingService
{
    Task<List<BookingDto>> GetAllBookingsAsync();
    Task<BookingDto?> GetBookingByIdAsync(int id);
    Task<List<BookingDto>> GetBookingsByCustomerIdAsync(int customerId);
    Task<ServiceResponse> UpdateBookingAsync(BookingDto booking);
    Task<ServiceResponse> DeleteBookingAsync(int id);
    Task<ServiceResponse> CreateBookingAsync(BookingDto booking);
}