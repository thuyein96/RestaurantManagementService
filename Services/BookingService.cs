namespace RestaurantManagementService.Services;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;

    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task<List<Booking>> GetAllBookingsAsync()
        => (await _bookingRepository.GetAllAsync()).ToList();

    public async Task<Booking?> GetBookingByIdAsync(int id)
        => await _bookingRepository.GetByIdAsync(id);

    public async Task<ServiceResponse> CreateBookingAsync(Booking booking)
    {
        if (await _bookingRepository.IsSlotTakenAsync(booking.BookingSlotId, booking.TableId))
        {
            return new ServiceResponse(false, "This table is already booked at the selected time slot.");
        }

        await _bookingRepository.AddAsync(booking);
        await _bookingRepository.SaveChangesAsync();

        return new ServiceResponse(true, "Booking created successfully.");
    }

    public async Task<ServiceResponse> UpdateBookingAsync(Booking booking)
    {
        await _bookingRepository.UpdateAsync(booking);
        await _bookingRepository.SaveChangesAsync();
        return new ServiceResponse
        (
            true,
            "Booking updated successfully."
        );
    }

    public async Task<ServiceResponse> DeleteBookingAsync(int id)
    {
        var booking = await _bookingRepository.GetByIdAsync(id);
        if (booking == null)
        {
            return new ServiceResponse(false, $"Booking with ID {id} not found.");
        }
        await _bookingRepository.DeleteAsync(booking);
        await _bookingRepository.SaveChangesAsync();
        return new ServiceResponse
        (
            true,
            "Booking deleted successfully."
        );
    }


}