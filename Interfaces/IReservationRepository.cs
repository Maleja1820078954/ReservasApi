using ReservasApi.Models;

namespace ReservasApi.Interfaces
{
    // interfaz: define QUÉ se debe hacer, pero NO cómo se hace.
    // que obliga a las clases a cumplir ciertas reglas.
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task<Reservation?> GetByIdAsync(int id);
        Task<IEnumerable<Reservation>> GetByClientIdAsync(int clientId);
        Task<Reservation> AddAsync(Reservation reservation);
        Task<Reservation?> UpdateAsync(int id, Reservation reservation);
        Task<bool> DeleteAsync(int id);
    }
}
