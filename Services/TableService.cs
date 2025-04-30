namespace RestaurantManagementService.Services;

public class TableService : ITableService
{
    private readonly ITableRepository _tableRepository;

    public TableService(ITableRepository tableRepository)
    {
        _tableRepository = tableRepository;
    }

    public async Task<List<Table>> GetAllTablesAsync() => (await _tableRepository.GetAllAsync()).ToList();
    public async Task<Table?> GetTableByIdAsync(int id) => await _tableRepository.GetByIdAsync(id);

    public async Task<ServiceResponse> UpdateTableAsync(Table table)
    {
        await _tableRepository.UpdateAsync(table);
        await _tableRepository.SaveChangesAsync();
        return new ServiceResponse
        (
            Flag: true,
            Message: "Table updated successfully."
        );
    }

    public async Task<ServiceResponse> DeleteTableAsync(int id)
    {
        var table = await _tableRepository.GetByIdAsync(id);
        if (table == null)
        {
            throw new Exception("Table not found.");
        }

        await _tableRepository.DeleteAsync(table);
        await _tableRepository.SaveChangesAsync();
        return new ServiceResponse
        (
            Flag: true,
            Message: "Table deleted successfully."
        );
    }

    public async Task<ServiceResponse> CreateTableAsync(Table table)
    {
        await _tableRepository.AddAsync(table);
        await _tableRepository.SaveChangesAsync();
        return new ServiceResponse
        (
            Flag: true,
            Message: "Table created successfully."
        );
    }
}