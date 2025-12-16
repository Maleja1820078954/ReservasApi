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
    [Route("api/[controller]")]
    //[Authorize]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationRepository _repo;

        public ReservationsController(IReservationRepository repo)
        {
            _repo = repo;
        }

        // GET: api/reservations
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reservations = await _repo.GetAllAsync();
            return Ok(reservations);
        }

        // GET: api/reservations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reservation = await _repo.GetByIdAsync(id);
            if (reservation == null) return NotFound();

            return Ok(reservation);
        }

        // GET: api/reservations/client/3
        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetByClient(int clientId)
        {
            var reservations = await _repo.GetByClientIdAsync(clientId);
            return Ok(reservations);
        }

        // POST: api/reservations
        [HttpPost]
        public async Task<IActionResult> Create(ReservationDto dto)
        {
            var reservation = new Reservation
            {
                Date = dto.Date,
                ClientId = dto.ClientId,
                ServiceId = dto.ServiceId,
                Status = "Pendiente"
            };

            var created = await _repo.AddAsync(reservation);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ReservationDto dto)
        {
            var reservation = new Reservation
            {
                Date = dto.Date,
                ClientId = dto.ClientId,
                ServiceId = dto.ServiceId,
                Status = dto.Status
            };

            var updated = await _repo.UpdateAsync(id, reservation);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repo.DeleteAsync(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
