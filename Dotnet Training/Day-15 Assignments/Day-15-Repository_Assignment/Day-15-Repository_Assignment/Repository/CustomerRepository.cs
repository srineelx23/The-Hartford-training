using Day_15_Repository_Assignment.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Day_15_Repository_Assignment.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly InsuranceContext _context;
        public CustomerRepository(InsuranceContext context) {
            _context = context;
        }
        public Task<List<Customer>> GetAllCustomersAsync()
        {
            return _context.Customers.Include(c=>c.Policies).ToListAsync();
        }
        public Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return _context.Customers.Include(c=>c.Policies).FirstOrDefaultAsync(c=>c.CustomerId==id);
        }
        public async Task CreateCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            
        }
        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return false; 
            await _context.Customers.Where(c=>c.CustomerId==id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            var cust=await _context.Customers.FindAsync(customer.CustomerId);
            if(cust==null) return false;
            cust.CustomerName = customer.CustomerName;
            cust.CustomerEmail = customer.CustomerEmail;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
