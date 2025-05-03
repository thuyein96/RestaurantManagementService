namespace RestaurantManagementService.Services;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly ITableRepository _tableRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly ITimeSlotRepository _timeSlotRepository;

    public BookingService(IBookingRepository bookingRepository,
                          ITableRepository tableRepository,
                          ICustomerRepository customerRepository,
                          ITimeSlotRepository timeSlotRepository)
    {
        _bookingRepository = bookingRepository;
        _tableRepository = tableRepository;
        _customerRepository = customerRepository;
        _timeSlotRepository = timeSlotRepository;
    }

    public async Task<List<BookingDto>> GetAllBookingsAsync()
    {
        var bookings = (await _bookingRepository.GetAllAsync()).ToList();
        var bookingDtos = new List<BookingDto>();
        foreach (var booking in bookings)
        {
            bookingDtos.Add(new BookingDto
            {
                Id = booking.Id,
                BookingNumber = booking.BookingNumber,
                NumberOfPeople = booking.NumberOfPeople,
                SpecialRequest = booking.SpecialRequest,
                IsConfirmed = booking.IsConfirmed,
                TableId = booking.Table.Id,
                CustomerId = booking.Customer.Id,
                BookingDate = booking.BookingDate.ToString("yyyy-MM-dd"),
                BookingSlotId = booking.BookingSlot.Id
            });
        }
        return bookingDtos;
    }

    public async Task<BookingDto?> GetBookingByIdAsync(int id)
    {
        var booking = await _bookingRepository.GetByIdAsync(id);
        if (booking == null)
        {
            return null;
        }
        return new BookingDto
        {
            Id = booking.Id,
            BookingNumber = booking.BookingNumber,
            NumberOfPeople = booking.NumberOfPeople,
            SpecialRequest = booking.SpecialRequest,
            IsConfirmed = booking.IsConfirmed,
            BookingDate = booking.BookingDate.ToString("yyyy-MM-dd"),
            TableId = booking.Table.Id,
            CustomerId = booking.Customer.Id,
            BookingSlotId = booking.BookingSlot.Id
        };
    }

    public async Task<List<BookingDto>> GetBookingsByCustomerIdAsync(int customerId)
    {
        var bookings = (await _bookingRepository.GetByCustomerIdAsync(customerId)).ToList();
        var bookingDtos = new List<BookingDto>();
        foreach (var booking in bookings)
        {
            bookingDtos.Add(new BookingDto
            {
                Id = booking.Id,
                BookingNumber = booking.BookingNumber,
                NumberOfPeople = booking.NumberOfPeople,
                SpecialRequest = booking.SpecialRequest,
                IsConfirmed = booking.IsConfirmed,
                BookingDate = booking.BookingDate.ToString("yyyy-MM-dd"),
                TableId = booking.Table.Id,
                CustomerId = booking.Customer.Id,
                BookingSlotId = booking.BookingSlot.Id
            });
        }
        return bookingDtos;
    }

    public async Task<ServiceResponse> CreateBookingAsync(BookingDto bookingDto)
    {
        var message = await ValidateBooking(bookingDto);

        if (!string.IsNullOrWhiteSpace(message))
        {
            return new ServiceResponse(false, message);
        }

        var table = await _tableRepository.GetByIdAsync(bookingDto.TableId);
        var customer = await _customerRepository.GetByIdAsync(bookingDto.CustomerId);
        var timeSlot = await _timeSlotRepository.GetByIdAsync(bookingDto.BookingSlotId);

        var booking = new Booking
        {
            BookingNumber = bookingDto.BookingNumber,
            NumberOfPeople = bookingDto.NumberOfPeople,
            SpecialRequest = bookingDto.SpecialRequest,
            IsConfirmed = bookingDto.IsConfirmed,
            BookingDate = DateOnly.Parse(bookingDto.BookingDate),
            TableId = table.Id,
            CustomerId = customer.Id,
            BookingSlotId = timeSlot.Id,
            Customer = customer!,
            Table = table!,
            BookingSlot = timeSlot!
        };

        await _bookingRepository.AddAsync(booking);
        await _bookingRepository.SaveChangesAsync();

        return new ServiceResponse(true, "Booking created successfully.");
    }

    public async Task<ServiceResponse> UpdateBookingAsync(BookingDto bookingDto)
    {
        var message = await ValidateBooking(bookingDto);
        if(!string.IsNullOrWhiteSpace(message))
        {
            return new ServiceResponse(false, message);
        }
        var table = await _tableRepository.GetByIdAsync(bookingDto.TableId);
        var customer = await _customerRepository.GetByIdAsync(bookingDto.CustomerId);
        var timeSlot = await _timeSlotRepository.GetByIdAsync(bookingDto.BookingSlotId);
        var booking = new Booking
        {
            BookingNumber = bookingDto.BookingNumber,
            NumberOfPeople = bookingDto.NumberOfPeople,
            SpecialRequest = bookingDto.SpecialRequest,
            IsConfirmed = bookingDto.IsConfirmed,
            BookingDate = DateOnly.Parse(bookingDto.BookingDate),
            TableId = bookingDto.TableId,
            CustomerId = bookingDto.CustomerId,
            BookingSlotId = bookingDto.BookingSlotId,
            Customer = customer!,
            Table = table!,
            BookingSlot = timeSlot!
        };

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

    private async Task<string> ValidateBooking(BookingDto bookingDto)
    {
        var message = string.Empty;
        var existingBooking = await _bookingRepository.IsSlotTakenAsync(bookingDto.BookingSlotId, bookingDto.TableId);
        if (existingBooking)
        {
            message = "This table is already booked at the selected time slot.";
        }
        if (DateOnly.Parse(bookingDto.BookingDate) < DateOnly.FromDateTime(DateTime.Now))
        {
            message = "Booking date cannot be in the past.";
        }
        if (bookingDto.NumberOfPeople <= 0)
        {
            message = "Number of people must be greater than zero.";
        }

        return message;
    }
}