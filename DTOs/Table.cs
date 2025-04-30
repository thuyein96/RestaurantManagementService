
namespace RestaurantManagementService.DTOs;

public class Table
{
    public int Id { get; set; }
    public int TableNumber { get; set; }
    public int NumberOfSeats { get; set; }
    public bool IsAvailable { get; set; }
}