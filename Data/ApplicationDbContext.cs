using Microsoft.EntityFrameworkCore;
using ReservasApi.Models;

namespace ReservasApi.Data
{
    // DbContext representa la sesión con la base de datos
    // Aquí se configuran las tablas y relaciones
    // Data ApplicationDbContext: Es la conexión entre tu API y la base de datos.
    public class ApplicationDbContext : DbContext
    {
        // Constructor del DbContext
        // Recibe las opciones de configuración (cadena de conexión, proveedor SQL, etc.)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // ==============================
        // TABLAS DE LA BASE DE DATOS
        // ==============================

        // Tabla Clients
        public DbSet<Client> Clients { get; set; }

        // Tabla Services
        public DbSet<Service> Services { get; set; }

        // Tabla Reservations
        public DbSet<Reservation> Reservations { get; set; }

        // Tabla Users (para login)
        public DbSet<User> Users { get; set; }

        // ==============================
        // CONFIGURACIÓN DEL MODELO
        // ==============================

        // OnModelCreating se ejecuta cuando EF crea el modelo de la BD
        // override permite personalizar el comportamiento por defecto de EF
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Llama a la configuración base de Entity Framework
            base.OnModelCreating(modelBuilder);

            // Define precisión del campo Price (decimal)
            // Evita errores de truncamiento en la base de datos
            modelBuilder.Entity<Service>()
                .Property(s => s.Price)
                .HasPrecision(10, 2);

            // RELACIÓN 1:N Client → Reservations

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Reservations)   // Un cliente tiene muchas reservas
                .WithOne(r => r.Client)         // Cada reserva pertenece a un cliente
                .HasForeignKey(r => r.ClientId) // Clave foránea
                .OnDelete(DeleteBehavior.Cascade); // Si se elimina el cliente, se eliminan sus reservas

         
            // RELACIÓN 1:N Service → Reservations

            modelBuilder.Entity<Service>()
                .HasMany(s => s.Reservations)   // Un servicio puede tener muchas reservas
                .WithOne(r => r.Service)        // Cada reserva pertenece a un servicio
                .HasForeignKey(r => r.ServiceId) // Clave foránea
                .OnDelete(DeleteBehavior.Cascade); // Eliminación en cascada
        }
    }
}
