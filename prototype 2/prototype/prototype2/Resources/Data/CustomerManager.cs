using prototype2.Resources.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CustomerManager
{
    private readonly MyDBContext _dbContext;

    public CustomerManager(MyDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Customer>> SearchCustomersAsync(string keyword)
    {
        return await _dbContext.Customers
            .Where(c => c.FirstName.Contains(keyword) || c.LastName.Contains(keyword) || c.Email.Contains(keyword))
            .ToListAsync();
    }

    public async Task<List<Customer>> GetAllCustomersAsync()
    {
        return await _dbContext.Customers.ToListAsync();
    }
    public async Task<int> GetNextCustomerIdAsync()
    {
        // Get the highest CustomerId in the database
        var highestId = await _dbContext.Customers
                                         .OrderByDescending(c => c.CustomerId)
                                         .Select(c => c.CustomerId)
                                         .FirstOrDefaultAsync();

        // Ensure the ID starts at 1004
        return highestId < 1004 ? 1004 : highestId + 1;
    }

    // Add a new customer
    public async Task<string> AddCustomerAsync(Customer newCustomer)
    {
        try
        {
            _dbContext.Customers.Add(newCustomer);
            await _dbContext.SaveChangesAsync();
            return "Customer added successfully.";
        }
        catch (Exception ex)
        {
            return $"Error adding customer: {ex.Message}";
        }
    }

    public async Task<string> DeleteCustomerAsync(int customerId)
    {
        var customer = await _dbContext.Customers.FindAsync(customerId);
        if (customer != null)
        {
            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();
            return "Customer deleted successfully.";
        }
        return "Customer not found.";
    }
}
