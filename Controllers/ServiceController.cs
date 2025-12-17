using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReservasApi.DTOs;
using ReservasApi.Interfaces;
using ReservasApi.Models;

namespace ReservasApi.Controllers
{
    // Controllers: Son los puntos de entrada de la API. Reciben solicitudes HTTP:
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _repo;

        public ServicesController(IServiceRepository repo)
        {
            _repo = repo;
        }

        // GET: api/services
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var services = await _repo.GetAllAsync();
            return Ok(services);
        }

        // GET: api/services/
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var service = await _repo.GetByIdAsync(id);
            if (service == null) return NotFound();

            return Ok(service);
        }

        // POST: api/services
        [HttpPost]
        public async Task<IActionResult> Create(ServiceDto dto)
        {
            var service = new Service
            {
                Name = dto.Name,
                Price = dto.Price
            };

            var created = await _repo.AddAsync(service);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/services/
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ServiceDto dto)
        {
            var service = new Service
            {
                Name = dto.Name,
                Price = dto.Price
            };

            var updated = await _repo.UpdateAsync(id, service);
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
