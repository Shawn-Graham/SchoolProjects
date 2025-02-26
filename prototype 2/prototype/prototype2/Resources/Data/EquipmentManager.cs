using Microsoft.EntityFrameworkCore;
using prototype2.Resources.Data;
public class EquipmentManager
{
    private readonly MyDBContext _dbContext;

    public EquipmentManager(MyDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Get all categories from the database
    public async Task<List<Category>> GetCategoriesAsync()
    {
        return await _dbContext.Categories.ToListAsync();
    }

    // Add new equipment with a dynamically generated EquipmentId based on CategoryId
    public async Task<string> AddEquipmentAsync(Equipment newEquipment)
    {
        try
        {
            // Retrieve the current max EquipmentId for the selected category from the database
            var maxEquipmentIdForCategory = await _dbContext.EquipmentList
                .Where(e => e.CategoryId == newEquipment.CategoryId) // Filter by CategoryId
                .OrderByDescending(e => e.EquipmentId) // Sort by EquipmentId descending
                .Select(e => e.EquipmentId)
                .FirstOrDefaultAsync();

            // Determine the prefix based on the CategoryId
            string categoryPrefix = newEquipment.CategoryId.ToString().PadLeft(1, '0'); // Ensure two digits

            // Generate the next EquipmentId based on the prefix
            int nextEquipmentId = (maxEquipmentIdForCategory >= 100)
                ? int.Parse(categoryPrefix + (maxEquipmentIdForCategory % 100).ToString().PadLeft(1, '0')) + 1
                : int.Parse(categoryPrefix + "00");

            // Set the EquipmentId for the new equipment
            newEquipment.EquipmentId = nextEquipmentId;

            // Add the new equipment to the database
            _dbContext.EquipmentList.Add(newEquipment);
            await _dbContext.SaveChangesAsync();

            return "Equipment added successfully.";
        }
        catch (Exception ex)
        {
            return $"Error adding equipment: {ex.Message}";
        }
    }

   // Delete equipment by ID
    public async Task<string> DeleteEquipmentAsync(int equipmentId)
    {
        try
        {
            var equipment = await _dbContext.EquipmentList.FindAsync(equipmentId);
            if (equipment == null)
            {
                return "Equipment not found.";
            }

            _dbContext.EquipmentList.Remove(equipment);
            await _dbContext.SaveChangesAsync();
            return "Equipment deleted successfully.";
        }
        catch (Exception ex)
        {
            return $"Error deleting equipment: {ex.Message}";
        }
    }

    // Search equipment by name or description
    public async Task<List<Equipment>> SearchEquipmentAsync(string keyword)
    {
        try
        {
            return await _dbContext.EquipmentList
                .Where(e => e.Name.Contains(keyword) || e.Description.Contains(keyword))
                .ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error searching equipment: {ex.Message}");
        }
    }
    public async Task<int> GetMaxEquipmentIdForCategoryAsync(int categoryId)
    {
        return await _dbContext.EquipmentList
            .Where(e => e.CategoryId == categoryId)
            .OrderByDescending(e => e.EquipmentId)
            .Select(e => e.EquipmentId)
            .FirstOrDefaultAsync();
    }

    // Get all equipment
    public async Task<List<Equipment>> GetAllEquipmentAsync()
    {
        try
        {
            return await _dbContext.EquipmentList.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error loading equipment: {ex.Message}");
        }
    }
}
