namespace RestaurantManagementService.Services;

public class TimeSlotService : ITimeSlotService
{
    private readonly ITimeSlotRepository _timeSlotRepository;

    public TimeSlotService(ITimeSlotRepository timeSlotRepository)
    {
        _timeSlotRepository = timeSlotRepository;
    }

    public async Task<List<TimeSlot>> GetAllTimeSlotsAsync() => (await _timeSlotRepository.GetAllAsync()).ToList();
    public async Task<TimeSlot?> GetTimeSlotByIdAsync(int id) => await _timeSlotRepository.GetByIdAsync(id);
    public async Task<ServiceResponse> UpdateTimeSlotAsync(TimeSlot timeSlot)
    {
        await _timeSlotRepository.UpdateAsync(timeSlot);
        await _timeSlotRepository.SaveChangesAsync();
        return new ServiceResponse(true, Message: "Time slot updated successfully.");
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

    public async Task<ServiceResponse> CreateTimeSlotAsync(TimeSlot timeSlot)
    {
        await _timeSlotRepository.AddAsync(timeSlot);
        await _timeSlotRepository.SaveChangesAsync();
        return new ServiceResponse(true, "Time slot created successfully.");
    }
}