using Microsoft.EntityFrameworkCore;
using prototype2.Resources.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class RentalManager
{
    private readonly MyDBContext _dbContext;

    public RentalManager(MyDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Get all rentals for a specific customer
    public async Task<List<Rental>> GetRentalsByCustomerAsync(int customerId)
    {
        return await _dbContext.Rentals
            .Where(r => r.CustomerId == customerId)
            .Include(r => r.Equipment)  // Load associated equipment
            .ToListAsync();
    }

    // Get available equipment
    public async Task<List<Equipment>> GetAvailableEquipmentAsync()
    {
        return await _dbContext.EquipmentList.ToListAsync();
    }

    // Get all customers
    public async Task<List<Customer>> GetCustomersAsync()
    {
        return await _dbContext.Customers.ToListAsync();
    }

    // Search rentals by customer keyword
    public async Task<List<Rental>> GetRentalsByCustomerKeywordAsync(string keyword)
    {
        return await _dbContext.Rentals
            .Include(r => r.Customer)
            .Include(r => r.Equipment)
            .Where(r => r.Customer.FirstName.Contains(keyword)
                        || r.Customer.LastName.Contains(keyword)
                        || r.Customer.Email.Contains(keyword))
            .ToListAsync();
    }

    // Get all rental IDs
    public async Task<List<int>> GetAllRentalIdsAsync()
    {
        return await _dbContext.Rentals.Select(r => r.RentalId).ToListAsync();
    }

    // Add a new rental
    public async Task<string> AddRentalAsync(Rental newRental)
    {
        try
        {
            // Generate a unique RentalId if necessary
            var allRentalIds = await GetAllRentalIdsAsync();
            newRental.RentalId = GenerateUniqueRentalId(allRentalIds);

            _dbContext.Rentals.Add(newRental);
            await _dbContext.SaveChangesAsync();
            return "Rental added successfully!";
        }
        catch (Exception ex)
        {
            return $"Error adding rental: {ex.Message}";
        }
    }

    // Generate a unique rental ID
    private int GenerateUniqueRentalId(List<int> existingIds)
    {
        int newId = 1; // Start from 1 or any other logic for RentalId generation
        while (existingIds.Contains(newId))
        {
            newId++;
        }
        return newId;
    }
}
