namespace RestaurantManagementService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeSlotController : ControllerBase
{
    private readonly ITimeSlotService _timeSlotService;

    public TimeSlotController(ITimeSlotService timeSlotService)
    {
        _timeSlotService = timeSlotService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTimeSlots()
    {
        var timeSlots = await _timeSlotService.GetAllTimeSlotsAsync();
        if (timeSlots.Count == 0 || timeSlots == null)
        {
            return NotFound("No time slots found.");
        }
        return Ok(timeSlots);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTimeSlotById(int id)
    {
        var timeSlot = await _timeSlotService.GetTimeSlotByIdAsync(id);
        if (timeSlot == null)
        {
            return NotFound($"Time slot with ID {id} not found.");
        }
        return Ok(timeSlot);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTimeSlot([FromBody] TimeSlot timeSlot)
    {
        if (timeSlot == null)
        {
            return BadRequest("Time slot cannot be null.");
        }
        var response = await _timeSlotService.CreateTimeSlotAsync(timeSlot);
        if (!response.Flag)
        {
            return BadRequest(response.Message);
        }
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTimeSlot([FromBody] TimeSlot timeSlot)
    {
        if (timeSlot == null)
        {
            return BadRequest("Time slot cannot be null.");
        }
        var response = await _timeSlotService.UpdateTimeSlotAsync(timeSlot);
        if (!response.Flag)
        {
            return BadRequest(response.Message);
        }
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTimeSlot(int id)
    {
        var response = await _timeSlotService.DeleteTimeSlotAsync(id);
        if (!response.Flag)
        {
            return BadRequest(response.Message);
        }
        return Ok(response);
    }
}