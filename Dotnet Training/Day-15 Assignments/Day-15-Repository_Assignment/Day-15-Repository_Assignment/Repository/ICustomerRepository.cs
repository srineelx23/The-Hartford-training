using Day_15_Repository_Assignment.Models;

namespace Day_15_Repository_Assignment.Repository
{
    public interface ICustomerRepository
    {

        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task CreateCustomerAsync(Customer customer);
        Task<bool> UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(int id);
    }
}
