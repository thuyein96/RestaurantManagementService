namespace RestaurantManagementService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TableController : ControllerBase
{
    private readonly ITableService _tableService;

    public TableController(ITableService tableService)
    {
        _tableService = tableService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTables()
    {
        var response = await _tableService.GetAllTablesAsync();
        if (response == null || response.Count == 0)
        {
            return NotFound("No tables found.");
        }
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTable(int id)
    {
        var response = await _tableService.GetTableByIdAsync(id);
        if (response == null)
        {
            return NotFound($"Table with ID {id} not found.");
        }
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTable([FromBody] Table table)
    {
        if (table == null)
        {
            return BadRequest("Table cannot be null.");
        }
        var response = await _tableService.CreateTableAsync(table);
        if (!response.Flag)
        {
            return BadRequest(response.Message);
        }
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTable([FromBody] Table table)
    {
        if (table == null)
        {
            return BadRequest("Value cannot be null or empty.");
        }
        var response = await _tableService.UpdateTableAsync(table);
        if (!response.Flag)
        {
            return BadRequest(response.Message);
        }
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTable(int id)
    {
        var response = await _tableService.DeleteTableAsync(id);
        if (!response.Flag)
        {
            return BadRequest(response.Message);
        }
        return Ok(response);
    }
}