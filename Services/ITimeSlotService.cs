namespace RestaurantManagementService.Services;

public interface ITimeSlotService
{
    Task<List<TimeSlotDto>> GetAllTimeSlotsAsync();
    Task<TimeSlotDto?> GetTimeSlotByIdAsync(int id);
    Task<ServiceResponse> UpdateTimeSlotAsync(TimeSlotDto timeSlot);
    Task<ServiceResponse> DeleteTimeSlotAsync(int id);
    Task<ServiceResponse> CreateTimeSlotAsync(TimeSlotDto timeSlot);
}