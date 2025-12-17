using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReservasApi.Controllers
{
    // Controllers: Son los puntos de entrada de la API. Reciben solicitudes HTTP:
    [Authorize] // ← PROTEGE TODAS LAS RUTAS
    [Route("api/[controller]")]
    [ApiController]

    public class EquipmentController : ControllerBase
    {
        // GET: api/<EquipmentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EquipmentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EquipmentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EquipmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EquipmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
