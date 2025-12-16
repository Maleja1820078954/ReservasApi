using System.ComponentModel.DataAnnotations;

namespace ReservasApi.DTOs
{
    // DTOs (Data Transfer Objects) Son clases que se usan para transportar
    // datos entre el cliente (frontend) y la API.
    public class ClientDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string FullName { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string Phone { get; set; } = "";
    }
}
