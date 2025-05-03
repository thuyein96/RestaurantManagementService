namespace RestaurantManagementService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBookings()
    {
        var bookings = await _bookingService.GetAllBookingsAsync();
        if (bookings.Count == 0 || bookings == null)
        {
            return NotFound("No booking found.");
        }
        return Ok(bookings);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookingById(int id)
    {
        var booking = await _bookingService.GetBookingByIdAsync(id);
        if (booking == null)
        {
            return NotFound($"Booking with ID {id} not found.");
        }
        return Ok(booking);
    }

    [HttpGet("Customer/{id}")]
    public async Task<IActionResult> GetBookingByCustomerId(int id)
    {
        var booking = await _bookingService.GetBookingsByCustomerIdAsync(id);
        if (booking == null)
        {
            return NotFound($"Booking with ID {id} not found.");
        }
        return Ok(booking);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBooking([FromBody] BookingDto bookingDto)
    {
        if (bookingDto == null)
        {
            return BadRequest("Booking cannot be null.");
        }
        var response = await _bookingService.CreateBookingAsync(bookingDto);
        if (!response.Flag)
        {
            return BadRequest(response.Message);
        }

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBooking([FromBody] BookingDto bookingDto)
    {
        if (bookingDto == null)
        {
            return BadRequest("Booking cannot be null.");
        }
        var response = await _bookingService.UpdateBookingAsync(bookingDto);
        if (!response.Flag)
        {
            return BadRequest(response.Message);
        }
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBooking(int id)
    {
        var response = await _bookingService.DeleteBookingAsync(id);
        if (!response.Flag)
        {
            return BadRequest(response.Message);
        }
        return Ok(response);
    }
}