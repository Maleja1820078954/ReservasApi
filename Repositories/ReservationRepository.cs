using Microsoft.EntityFrameworkCore;
using ReservasApi.Data;
using ReservasApi.Interfaces;
using ReservasApi.Models;

namespace ReservasApi.Repositories
{
    // Repositories: sirven para manejar el acceso a la base de datos y
    // separarlo de los controladores.
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _context.Reservations
                .Include(r => r.Client)
                .Include(r => r.Service)
                .ToListAsync();
        }

        public async Task<Reservation?> GetByIdAsync(int id)
        {
            return await _context.Reservations
                .Include(r => r.Client)
                .Include(r => r.Service)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Reservation>> GetByClientIdAsync(int clientId)
        {
            return await _context.Reservations
                .Where(r => r.ClientId == clientId)
                .Include(r => r.Service)
                .ToListAsync();
        }

        public async Task<Reservation> AddAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task<Reservation?> UpdateAsync(int id, Reservation reservation)
        {
            var existing = await _context.Reservations.FindAsync(id);
            if (existing == null) return null;

            existing.Date = reservation.Date;
            existing.ClientId = reservation.ClientId;
            existing.ServiceId = reservation.ServiceId;
            existing.Status = reservation.Status;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Reservations.FindAsync(id);
            if (existing == null) return false;

            _context.Reservations.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
