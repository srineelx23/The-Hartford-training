using Day_15_Repository_Assignment.Models;
using Day_15_Repository_Assignment.Repository;

namespace Day_15_Repository_Assignment.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Task<List<Customer>> GetAllCustomersAsync()
        {
            return _customerRepository.GetAllCustomersAsync();
        }
        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetCustomerByIdAsync(id);
        }
        public async Task CreateCustomerAsync(Customer customer)
        {
            if(string.IsNullOrEmpty(customer.CustomerName))
            {
                throw new ArgumentException("Customer name and email cannot be empty.");
            }
            await _customerRepository.CreateCustomerAsync(customer);
        }
        public async Task<bool> DeleteCustomerAsync(int id)
        {
            return await _customerRepository.DeleteCustomerAsync(id);
        }
        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            if(string.IsNullOrEmpty(customer.CustomerName))
            {
                throw new ArgumentException("Customer name and email cannot be empty.");
            }
            return await _customerRepository.UpdateCustomerAsync(customer);
        }
    }
}
