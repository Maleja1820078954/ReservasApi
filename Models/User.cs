namespace ReservasApi.Models
{
    // Los modelos son clases que representan los datos del sistema y
    // cómo se guardan en la base de datos.
    // Un hash es el resultado de aplicar un algoritmo matemático a un dato
    // (por ejemplo una contraseña) para convertirlo en una cadena irreconocible.
    // Sirve para proteger contraseñas
    public class User
    {
        public int Id { get; set; }

        // Nombre de usuario con el que inicia sesión
        public string Username { get; set; } = string.Empty;

        // Contraseña en formato HASH (nunca se guarda la contraseña real)
        public string PasswordHash { get; set; } = string.Empty;

    }
}
