namespace RestaurantManagementService.DTOs;

public class Bookings
{
    public int Id { get; set; }
    public int BookingNumber { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public int NumberOfPeople { get; set; }
    public string SpecialRequest { get; set; }
    public bool IsConfirmed { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public int TableId { get; set; }
    public Table Table { get; set; }

    public int BookingSlotId { get; set; }
    public TimeSlot BookingSlot { get; set; }
}