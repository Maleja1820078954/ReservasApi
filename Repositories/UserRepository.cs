using ReservasApi.Data;
using ReservasApi.Interfaces;
using ReservasApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ReservasApi.Repositories
{
    // Interfaz que define qué operaciones deben implementarse para manejar usuarios.
    // Separa el contrato de la implementación.
    // Implementación del repositorio con EF Core.
    // Repositories: sirven para manejar el acceso a la base de datos y
    // separarlo de los controladores.
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        // Buscar usuario por su nombre de usuario
        public async Task<User?> GetByUserNameAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == userName);
        }

        // Registrar un nuevo usuario
        public async Task<User> RegisterAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}