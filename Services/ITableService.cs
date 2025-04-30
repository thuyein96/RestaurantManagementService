namespace RestaurantManagementService.Services;

public interface ITableService
{
    Task<List<Table>> GetAllTablesAsync();
    Task<Table?> GetTableByIdAsync(int id);
    Task<ServiceResponse> UpdateTableAsync(Table table);
    Task<ServiceResponse> DeleteTableAsync(int id);
    Task<ServiceResponse> CreateTableAsync(Table table);
}