namespace RestaurantManagementService.Services;

public interface ITableService
{
    Task<List<TableDto>> GetAllTablesAsync();
    Task<TableDto?> GetTableByIdAsync(int id);
    Task<ServiceResponse> UpdateTableAsync(TableDto table);
    Task<ServiceResponse> DeleteTableAsync(int id);
    Task<ServiceResponse> CreateTableAsync(TableDto table);
}