namespace RestaurantManagementService.Services;

public interface ICustomerService
{
    Task<List<Customer>> GetAllCustomersAsync();
    Task<Customer?> GetCustomerByIdAsync(int id);
    Task<ServiceResponse> CreateCustomerAsync(Customer customer);
    Task<ServiceResponse> UpdateCustomerAsync(Customer customer);
    Task<ServiceResponse> DeleteCustomerAsync(int id);
}