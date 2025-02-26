using System.Linq;
using System.Threading.Tasks;
using GymManagmentFinalProject.Components.Pages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GymManagmentFinalProject.Resources.Data
{
    public class EquipmentClass
    {
        private readonly DatabaseConnection _context;

        public EquipmentClass(DatabaseConnection context)
        {
            _context = context;
        }


        public async Task<List<EquipmentList>> LoadEquipment()
        {
            return await _context.EquipmentList.ToListAsync();
        }

        public async Task<List<EquipmentList>> SearchEquipment(string searchQuery)
        {
            if (int.TryParse(searchQuery, out int equipmentId))
            {
                return await _context.EquipmentList
                    .Where(e => e.EquipmentId == equipmentId)
                    .ToListAsync();
            }
            else
            {
                return await _context.EquipmentList
                    .Where(e => e.EquipmentName == searchQuery)
                    .ToListAsync();
            }
        }

        public async Task DeleteEquipment(int equipmentId)
        {
            var equipment = await _context.EquipmentList
                .FirstOrDefaultAsync(c => c.EquipmentId == equipmentId);

            if (equipment != null)
            {
                _context.EquipmentList.Remove(equipment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ChangeStatus(EquipmentList item)
        {
            _context.EquipmentList.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
