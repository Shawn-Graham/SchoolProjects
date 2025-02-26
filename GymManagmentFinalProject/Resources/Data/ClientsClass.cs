using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GymManagmentFinalProject.Resources.Data
{
    public class ClientsClass
    {
        private readonly DatabaseConnection _context;

        public ClientsClass(DatabaseConnection context)
        {
            _context = context;
        }

        // Method to get all clients from the database using Entity Framework
        public async Task<List<Clients>> GetAllClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        // Method to search clients based on the query (ID, FirstName, LastName)
        public async Task<List<Clients>> SearchClientsAsync(string searchQuery)
        {
            if (int.TryParse(searchQuery, out int clientId))
            {
                return await _context.Clients
                    .Where(c => c.MemberId == clientId)
                    .ToListAsync();
            }
            else
            {
                return await _context.Clients
                    .Where(c => c.FirstName.Contains(searchQuery) || c.LastName.Contains(searchQuery))
                    .ToListAsync();
            }
        }

        // Method to add a new client
        public async Task AddClientAsync(Clients client)
        {
            var maxMemberId = await _context.Clients
                .OrderByDescending(c => c.MemberId)
                .Select(c => c.MemberId)
                .FirstOrDefaultAsync();

            client.MemberId = maxMemberId + 1;
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        // Method to delete a client from the database
        public async Task DeleteClientAsync(int clientId)
        {
            var client = await _context.Clients
                .FirstOrDefaultAsync(c => c.MemberId == clientId);

            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }

        // Method to update the client's status
        public async Task UpdateClientAsync(Clients client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
        }
    }
}
