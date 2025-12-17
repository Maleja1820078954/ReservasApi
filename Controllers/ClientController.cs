using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReservasApi.DTOs;
using ReservasApi.Interfaces;
using ReservasApi.Models;

namespace ReservasApi.Controllers
{
    // Controllers: Son los puntos de entrada de la API. Reciben solicitudes HTTP:
    // Indica que esta clase es un controlador de API
    [ApiController]

    // Define la ruta base: api/client
    [Route("api/[controller]")]

    // Protege todos los endpoints con JWT
    // Solo usuarios autenticados pueden acceder
    [Authorize]
    public class ClientController : ControllerBase
    {
        // Repositorio para acceder a los datos de clientes
        private readonly IClientRepository _repo;

        // Inyección de dependencias
        // ASP.NET inyecta automáticamente el repositorio
        public ClientController(IClientRepository repo)
        {
            _repo = repo;
        }

        // ==============================
        // GET: api/client
        // Obtiene todos los clientes
        // ==============================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _repo.GetAllAsync();
            return Ok(clients);
        }

        // ==============================
        // GET: api/client/{id}
        // Obtiene un cliente por su ID
        // ==============================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await _repo.GetByIdAsync(id);
            if (client == null)
                return NotFound();

            return Ok(client);
        }

        // ==============================
        // POST: api/client
        // Crea un nuevo cliente
        // ==============================
        [HttpPost]
        public async Task<IActionResult> Create(ClientDto dto)
        {
            // Convierte el DTO en una entidad Client
            var client = new Client
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone
            };

            // Guarda el cliente en la base de datos
            var created = await _repo.AddAsync(client);

            // Devuelve HTTP 201 con la ubicación del recurso creado
            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                created
            );
        }

        // ==============================
        // PUT: api/client/{id}
        // Actualiza un cliente existente
        // ==============================
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ClientDto dto)
        {
            // Crea un objeto con los nuevos datos
            var client = new Client
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone
            };

            // Actualiza el cliente
            var updated = await _repo.UpdateAsync(id, client);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // ==============================
        // DELETE: api/client/{id}
        // Elimina un cliente
        // ==============================
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repo.DeleteAsync(id);
            if (!result)
                return NotFound();

            // NoContent indica que la eliminación fue exitosa
            return NoContent();
        }
    }
}
