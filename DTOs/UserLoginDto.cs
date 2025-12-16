using System.ComponentModel.DataAnnotations;

namespace ReservasApi.DTOs
{
    // DTOs (Data Transfer Objects) Son clases que se usan para transportar
    // datos entre el cliente (frontend) y la API.
    public class UserLoginDto
    {
        // DTO utilizado para iniciar sesión
        [Required]
        // Se usa string.Empty o "" para inicializar propiedades string y evitar valores null,
        // previniendo errores y mejorando la seguridad del código.
        public string Username { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
    }
}