namespace ReservasApi.DTOs
{
    // DTOs (Data Transfer Objects) Son clases que se usan para transportar
    // datos entre el cliente (frontend) y la API.
    public class ReservationDto
    {
        public DateTime Date { get; set; }

        public int ClientId { get; set; }

        public int ServiceId { get; set; }

        public string Status { get; set; } = "Pendiente";
    }
}
