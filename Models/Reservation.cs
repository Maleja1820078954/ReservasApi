namespace ReservasApi.Models
{
    // Los modelos son clases que representan los datos del sistema y
    // cómo se guardan en la base de datos.
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } = "Pendiente";

        // Foreign keys - Relación con Cliente
        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;

        // Relación con Servicio
        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;

    }
}
