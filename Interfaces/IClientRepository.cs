using ReservasApi.Models;

namespace ReservasApi.Interfaces
{
    // interfaz: define QUÉ se debe hacer, pero NO cómo se hace.
    // que obliga a las clases a cumplir ciertas reglas.
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client?> GetByIdAsync(int id);
        Task<Client> AddAsync(Client client);
        Task<Client?> UpdateAsync(int id, Client client);
        Task<bool> DeleteAsync(int id);
    }
}
