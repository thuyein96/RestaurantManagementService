namespace RestaurantManagementService.Repositories;

public class TableRepository : ITableRepository
{
    private readonly AppDbContext _context;

    public TableRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Table>> GetAllAsync()
    {
        return await _context.Tables.ToListAsync();
    }

    public async Task<Table?> GetByIdAsync(int id)
    {
        return await _context.Tables.FindAsync(id);
    }

    public async Task AddAsync(Table table)
    {
        await _context.Tables.AddAsync(table);
    }

    public async Task DeleteAsync(Table table)
    {
        _context.Tables.Remove(table);
    }
    public async Task UpdateAsync(Table table)
    {
        _context.Tables.Update(table);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}