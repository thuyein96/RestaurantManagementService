namespace RestaurantManagementService.DTOs;

public class BookingDto
{
    public int Id { get; set; }
    public int BookingNumber { get; set; }
    public int NumberOfPeople { get; set; }
    public string SpecialRequest { get; set; }
    public bool IsConfirmed { get; set; }
    public string BookingDate { get; set; }
    public int TableId { get; set; }
    public int CustomerId { get; set; }
    public int BookingSlotId { get; set; }
}