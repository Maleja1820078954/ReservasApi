using ReservasApi.Models;

namespace ReservasApi.Interfaces
{
    // interfaz: define QUÉ se debe hacer, pero NO cómo se hace.
    // que obliga a las clases a cumplir ciertas reglas.
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllAsync();
        Task<Service?> GetByIdAsync(int id);
        Task<Service> AddAsync(Service service);
        Task<Service?> UpdateAsync(int id, Service service);
        Task<bool> DeleteAsync(int id);
    }
}
