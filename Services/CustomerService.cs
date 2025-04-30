namespace RestaurantManagementService.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<List<Customer>> GetAllCustomersAsync()
        => (await _customerRepository.GetAllAsync()).ToList();

    public async Task<Customer?> GetCustomerByIdAsync(int id)
    => await _customerRepository.GetByIdAsync(id);

    public async Task<ServiceResponse> CreateCustomerAsync(Customer customer)
    {
        await _customerRepository.AddAsync(customer);
        await _customerRepository.SaveChangesAsync();
        return new ServiceResponse(true, "Customer created successfully");
    }

    public async Task<ServiceResponse> UpdateCustomerAsync(Customer customer)
    {
        await _customerRepository.UpdateAsync(customer);
        await _customerRepository.SaveChangesAsync();
        return new ServiceResponse(true, "Customer updated successfully");
    }

    public async Task<ServiceResponse> DeleteCustomerAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer == null)
        {
            return new ServiceResponse(false, $"Customer with ID {id} not found.");
        }
        await _customerRepository.DeleteAsync(customer);
        await _customerRepository.SaveChangesAsync();
        return new ServiceResponse(true, "Customer deleted successfully");
    }
}