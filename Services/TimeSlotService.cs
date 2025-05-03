using RestaurantManagementService.DTOs;

namespace RestaurantManagementService.Services;

public class TimeSlotService : ITimeSlotService
{
    private readonly ITimeSlotRepository _timeSlotRepository;

    public TimeSlotService(ITimeSlotRepository timeSlotRepository)
    {
        _timeSlotRepository = timeSlotRepository;
    }

    public async Task<List<TimeSlotDto>> GetAllTimeSlotsAsync()
    {
        var slots = (await _timeSlotRepository.GetAllAsync()).ToList();
        if (slots.Count == 0 || slots == null) return null;
        var timeSlots = new List<TimeSlotDto>();
        foreach (var slot in slots)
        {
            timeSlots.Add(new TimeSlotDto
            {
                Id = slot.Id,
                SlotId = slot.SlotId,
                Time = slot.Time.ToString("HH:mm:ss")
            });
        }
        return timeSlots;
    }

    public async Task<TimeSlotDto?> GetTimeSlotByIdAsync(int id)
    {
        var slot = await _timeSlotRepository.GetByIdAsync(id);
        if (slot == null) return null;
        return new TimeSlotDto
        {
            Id = slot.Id,
            SlotId = slot.SlotId,
            Time = slot.Time.ToString("HH:mm:ss")
        };
    }

    public async Task<ServiceResponse> UpdateTimeSlotAsync(TimeSlotDto timeSlot)
    {
        var existingSlot = await _timeSlotRepository.GetByIdAsync(timeSlot.Id);
        if (existingSlot == null) return new ServiceResponse(false, "Time slot not found.");

        existingSlot.Id = timeSlot.Id;
        existingSlot.SlotId = timeSlot.SlotId;
        existingSlot.Time = TimeOnly.FromDateTime(DateTime.Parse(timeSlot.Time)); 

        await _timeSlotRepository.UpdateAsync(existingSlot);
        await _timeSlotRepository.SaveChangesAsync();
        return new ServiceResponse(true, "Time slot updated successfully.");
    }

    public async Task<ServiceResponse> DeleteTimeSlotAsync(int id)
    {
        var timeSlot = await _timeSlotRepository.GetByIdAsync(id);
        if (timeSlot == null)
        {
            return new ServiceResponse(false, "Time slot not found.");
        }

        await _timeSlotRepository.DeleteAsync(timeSlot);
        await _timeSlotRepository.SaveChangesAsync();
        return new ServiceResponse(true, "Time slot deleted successfully.");
    }

    public async Task<ServiceResponse> CreateTimeSlotAsync(TimeSlotDto timeSlotDto)
    {
        var timeSlot = new TimeSlot
        {
            Id = timeSlotDto.Id,
            SlotId = timeSlotDto.SlotId,
            Time = TimeOnly.FromDateTime(DateTime.Parse(timeSlotDto.Time)), 
            Bookings = new List<Booking>()
        };
        await _timeSlotRepository.AddAsync(timeSlot);
        await _timeSlotRepository.SaveChangesAsync();
        return new ServiceResponse(true, "Time slot created successfully.");
    }
}