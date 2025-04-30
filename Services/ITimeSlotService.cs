namespace RestaurantManagementService.Services;

public interface ITimeSlotService
{
    Task<List<TimeSlot>> GetAllTimeSlotsAsync();
    Task<TimeSlot?> GetTimeSlotByIdAsync(int id);
    Task<ServiceResponse> UpdateTimeSlotAsync(TimeSlot timeSlot);
    Task<ServiceResponse> DeleteTimeSlotAsync(int id);
    Task<ServiceResponse> CreateTimeSlotAsync(TimeSlot timeSlot);
}