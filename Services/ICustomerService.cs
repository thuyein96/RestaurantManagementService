namespace RestaurantManagementService.Services;

public interface ICustomerService
{
    Task<List<CustomerDto>> GetAllCustomersAsync();
    Task<CustomerDto?> GetCustomerByIdAsync(int id);
    Task<ServiceResponse> CreateCustomerAsync(CustomerDto customer);
    Task<ServiceResponse> UpdateCustomerAsync(CustomerDto customer);
    Task<ServiceResponse> DeleteCustomerAsync(int id);
}