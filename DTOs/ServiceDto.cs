namespace ReservasApi.DTOs
{
    // DTOs (Data Transfer Objects) Son clases que se usan para transportar
    // datos entre el cliente (frontend) y la API.
    public class ServiceDto
    {
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}
