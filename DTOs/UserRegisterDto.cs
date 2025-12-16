using System.ComponentModel.DataAnnotations;

namespace ReservasApi.DTOs
{
    // DTO utilizado cuando un usuario quiere registrarse.
    // Solo se reciben datos necesarios, no se exponen propiedades internas.

    public class UserRegisterDto
    {
        [Required]
        public string UserName { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
    }
}