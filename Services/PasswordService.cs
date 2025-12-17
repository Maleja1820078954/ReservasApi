using System.Security.Cryptography;
using System.Text;
// Servicio que se encarga de convertir contraseñas a HASH seguro.
namespace ReservasApi.Services
{
    public class PasswordService
    {
        // Un hash es el resultado de aplicar un algoritmo matemático a un dato
        // (por ejemplo una contraseña) para convertirlo en una cadena irreconocible.
        // Sirve para proteger contraseñas

        // Convierte una contraseña a HASH usando SHA256ac
        public string Hash(string password)
        {
            var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        // Verifica si una contraseña es igual al hash guardado
        public bool Verify(string password, string hash)
        {
            return Hash(password) == hash;
        }

    }
}

