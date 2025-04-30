namespace RestaurantManagementService.DTOs;

public class TimeSlot
{
    public int Id { get; set; }
    public int SlotId { get; set; }
    public DateTime DateTime { get; set; }
    public string SlotName { get; set; }
    public bool IsAvailable { get; set; }

}