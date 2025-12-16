namespace ReservasApi.Models
{
    // Los modelos son clases que representan los datos del sistema y
    // cómo se guardan en la base de datos.
    public class Client
    {
        public int Id { get; set; }
        // string.Empty: Inicializan la propiedad como una cadena vacía, no como null.
        // Evitan errores cuando el valor todavía no ha sido asignado.
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        // Relación 1 → muchos (Cliente puede tener muchas reservas)
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
