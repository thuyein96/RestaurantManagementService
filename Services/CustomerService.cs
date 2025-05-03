namespace RestaurantManagementService.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<List<CustomerDto>> GetAllCustomersAsync()
    {
        var customers = (await _customerRepository.GetAllAsync()).ToList();
        if (customers.Count == 0 || customers == null) return null;

        var customerDtos = new List<CustomerDto>();
        foreach (var customer in customers)
        {
            customerDtos.Add(new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
            });
        }
        return customerDtos;
    } 

    public async Task<CustomerDto?> GetCustomerByIdAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer == null) return null;
        return new CustomerDto
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
        };
    }

    public async Task<ServiceResponse> CreateCustomerAsync(CustomerDto customerDto)
    {
        var customer = new Customer
        {
            Id = customerDto.Id,
            Name = customerDto.Name,
            PhoneNumber = customerDto.PhoneNumber,
            Email = customerDto.Email,
            Bookings = new List<Booking>()
        };

        await _customerRepository.AddAsync(customer);
        await _customerRepository.SaveChangesAsync();
        return new ServiceResponse(true, "Customer created successfully");
    }

    public async Task<ServiceResponse> UpdateCustomerAsync(CustomerDto customerDto)
    {
        var customer = await _customerRepository.GetByIdAsync(customerDto.Id);
        if (customer == null)
        {
            return new ServiceResponse(false, $"Customer with ID {customerDto.Id} not found.");
        }

        customer.Name = customerDto.Name;
        customer.PhoneNumber = customerDto.PhoneNumber;
        customer.Email = customerDto.Email;

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