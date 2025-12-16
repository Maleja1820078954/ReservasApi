namespace ReservasApi.Models
{
    // Los modelos son clases que representan los datos del sistema y
    // cómo se guardan en la base de datos.
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        // Relación 1 → muchos (un servicio puede ser usado en muchas reservas)
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
