using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GymManagmentFinalProject.Resources.Data
{
    public class EmployeesClass
    {
        private readonly DatabaseConnection _context;

        public EmployeesClass(DatabaseConnection context)
        {
            _context = context;
        }

        // Method to get all employees from the database using Entity Framework
        public async Task<List<Employees>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        // Method to get a simplified list of employees with only ID and Name for the dropdown
        public async Task<List<EmployeeDropdown>> GetEmployeeDropdownAsync()
        {
            return await _context.Employees
                .Select(e => new EmployeeDropdown
                {
                    EmployeeId = e.EmployeeId,
                    EmployeeName = $"{e.FirstName} {e.LastName}"
                })
                .ToListAsync();
        }

        // Method to search employees based on the query (ID, First Name, or Last Name)
        public async Task<List<Employees>> SearchEmployeesAsync(string searchQuery)
        {
            // Convert search query to an integer if possible (for EmployeeId)
            if (int.TryParse(searchQuery, out int employeeId))
            {
                return await _context.Employees
                    .Where(e => e.EmployeeId == employeeId)
                    .ToListAsync();
            }

            return await _context.Employees
                .Where(e => e.FirstName.Contains(searchQuery) || e.LastName.Contains(searchQuery))
                .ToListAsync();
        }

        // Method to add a new employee to the database
        public async Task AddEmployeeAsync(Employees employee)
        {
            var maxEmployeeId = _context.Employees.Any()
                ? _context.Employees.Max(e => e.EmployeeId)
                : 0;
            employee.EmployeeId = maxEmployeeId + 1;

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        // Method to delete an employee
        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        // Method to get a single employee by their EmployeeId
        public async Task<Employees> GetEmployeeByIdAsync(int employeeId)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }
    }

    // Create a simplified EmployeeDropdown model for the dropdown list
    public class EmployeeDropdown
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}
