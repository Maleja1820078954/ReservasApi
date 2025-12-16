using Microsoft.EntityFrameworkCore;
using ReservasApi.Data;
using ReservasApi.Interfaces;
using ReservasApi.Models;

namespace ReservasApi.Repositories
{
    // Repositories: sirven para manejar el acceso a la base de datos y
    // separarlo de los controladores.
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetAllAsync() =>
            await _context.Services.ToListAsync();

        public async Task<Service?> GetByIdAsync(int id) =>
            await _context.Services.FindAsync(id);

        public async Task<Service> AddAsync(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task<Service?> UpdateAsync(int id, Service service)
        {
            var existing = await _context.Services.FindAsync(id);
            if (existing == null) return null;

            existing.Name = service.Name;
            existing.Price = service.Price;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Services.FindAsync(id);
            if (existing == null) return false;

            _context.Services.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
