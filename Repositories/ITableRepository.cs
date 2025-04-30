namespace RestaurantManagementService.Repositories;

public interface ITableRepository
{
    Task<IEnumerable<Table>> GetAllAsync();
    Task<Table?> GetByIdAsync(int id);
    Task AddAsync(Table table);
    Task DeleteAsync(Table table);
    Task UpdateAsync(Table table);
    Task SaveChangesAsync();
}