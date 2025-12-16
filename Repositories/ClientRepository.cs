using Microsoft.EntityFrameworkCore;
using ReservasApi.Data;
using ReservasApi.Interfaces;
using ReservasApi.Models;

namespace ReservasApi.Repositories
{
    // Repositories: sirven para manejar el acceso a la base de datos y
    // separarlo de los controladores.
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAllAsync() =>
            await _context.Clients.ToListAsync();

        public async Task<Client?> GetByIdAsync(int id) =>
            await _context.Clients.FindAsync(id);

        public async Task<Client> AddAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Client?> UpdateAsync(int id, Client client)
        {
            var existing = await _context.Clients.FindAsync(id);
            if (existing == null) return null;

            existing.FullName = client.FullName;
            existing.Email = client.Email;
            existing.Phone = client.Phone;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Clients.FindAsync(id);
            if (existing == null) return false;

            _context.Clients.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
