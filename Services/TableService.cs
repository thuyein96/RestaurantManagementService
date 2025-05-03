namespace RestaurantManagementService.Services;

public class TableService : ITableService
{
    private readonly ITableRepository _tableRepository;

    public TableService(ITableRepository tableRepository)
    {
        _tableRepository = tableRepository;
    }

    public async Task<List<TableDto>> GetAllTablesAsync()
    {
        var tables = (await _tableRepository.GetAllAsync()).ToList();
        var tableDtos = new List<TableDto>();
        foreach(var table in tables)
        {
            tableDtos.Add(new TableDto
            {
                Id = table.Id,
                TableNumber = table.TableNumber,
                NumberOfSeats = table.NumberOfSeats,
            });
        }
        return tableDtos;
    }

    public async Task<TableDto?> GetTableByIdAsync(int id)
    {
        var table = await _tableRepository.GetByIdAsync(id);
        if (table == null) return null;

        return new TableDto
        {
            Id = table.Id,
            TableNumber = table.TableNumber,
            NumberOfSeats = table.NumberOfSeats
        };
    }

    public async Task<ServiceResponse> UpdateTableAsync(TableDto table)
    {
        var existingTable = await _tableRepository.GetByIdAsync(table.Id);
        if (existingTable == null) return new ServiceResponse(false, "Table not found.");

        existingTable.Id = table.Id;
        existingTable.TableNumber = table.TableNumber;
        existingTable.NumberOfSeats = table.NumberOfSeats;

        await _tableRepository.UpdateAsync(existingTable);
        await _tableRepository.SaveChangesAsync();
        return new ServiceResponse
        (
            Flag: true,
            Message: "Table updated successfully."
        );
    }

    public async Task<ServiceResponse> DeleteTableAsync(int id)
    {
        try
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
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse> CreateTableAsync(TableDto tableDto)
    {
        var table = new Table
        {
            Id = tableDto.Id,
            TableNumber = tableDto.TableNumber,
            NumberOfSeats = tableDto.NumberOfSeats,
            Bookings = new List<Booking>()
        };

        await _tableRepository.AddAsync(table);
        await _tableRepository.SaveChangesAsync();
        return new ServiceResponse
        (
            Flag: true,
            Message: "Table created successfully."
        );
    }
}