namespace RestaurantManagementService.Models;

public class TimeSlot
{
    public int Id { get; set; }
    public int SlotId { get; set; }
    public TimeOnly Time { get; set; }
    public ICollection<Booking> Bookings { get; set; }

}