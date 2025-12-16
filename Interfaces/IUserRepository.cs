using ReservasApi.Models;

namespace ReservasApi.Interfaces
{
    // interfaz: define QUÉ se debe hacer, pero NO cómo se hace.
    // que obliga a las clases a cumplir ciertas reglas.
    public interface IUserRepository
    {
        // Interfaz que define qué operaciones deben implementarse para manejar usuarios.
        // Separa el contrato de la implementación.

        Task<User?> GetByUserNameAsync(string userName);
        Task<User> RegisterAsync(User user);
    }
}