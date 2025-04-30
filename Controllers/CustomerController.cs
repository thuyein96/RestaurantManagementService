namespace RestaurantManagementService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customers = await _customerService.GetAllCustomersAsync();
        if (customers.Count == 0 || customers == null)
        {
            return NotFound("No customer found.");
        }
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);
        if (customer == null)
        {
            return NotFound($"Customer with ID {id} not found.");
        }
        return Ok(customer);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
    {
        if (customer == null)
        {
            return BadRequest("Customer cannot be null.");
        }
        var response = await _customerService.CreateCustomerAsync(customer);
        if (!response.Flag)
        {
            return BadRequest(response.Message);
        }
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
    {
        if (customer == null)
        {
            return BadRequest("Customer cannot be null.");
        }
        var response = await _customerService.UpdateCustomerAsync(customer);
        if (!response.Flag)
        {
            return BadRequest(response.Message);
        }
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var response = await _customerService.DeleteCustomerAsync(id);
        if (!response.Flag)
        {
            return BadRequest(response.Message);
        }
        return Ok(response);
    }
}