using Microsoft.AspNetCore.Mvc;
using ReservasApi.DTOs;
using ReservasApi.Interfaces;
using ReservasApi.Models;
using ReservasApi.Services;

namespace ReservasApi.Controllers
{
    // Controllers: Son los puntos de entrada de la API. Reciben solicitudes HTTP:
    // Indica que esta clase es un controlador de API
    // Habilita validaciones automáticas y respuestas HTTP correctas
    //  Hypertext Transfer Protocol (Protocolo de Transferencia de Hipertexto)
    [ApiController]

    // Define la ruta base del controlador: api/auth
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // Repositorio para acceder a los usuarios en la base de datos
        private readonly IUserRepository _users;

        // Servicio para encriptar y verificar contraseñas
        private readonly PasswordService _passwords;

        // Servicio para generar el token JWT
        private readonly JwtService _jwt;

        // Constructor con inyección de dependencias
        // ASP.NET inyecta automáticamente estos servicios
        public AuthController(
            IUserRepository users,
            PasswordService passwords,
            JwtService jwt)
        {
            _users = users;
            _passwords = passwords;
            _jwt = jwt;
        }

        // ==============================
        // ENDPOINT DE REGISTRO
        // POST: api/auth/register
        // ==============================
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            // Verifica si el usuario ya existe por nombre de usuario
            var exists = await _users.GetByUserNameAsync(dto.UserName);
            if (exists != null)
                return BadRequest("El usuario ya existe");

            // Crea un nuevo usuario
            var user = new User
            {
                Username = dto.UserName,
                // Se guarda la contraseña encriptada, no en texto plano
                PasswordHash = _passwords.Hash(dto.Password)
            };

            // Guarda el usuario en la base de datos
            await _users.RegisterAsync(user);

            // Respuesta exitosa
            return Ok("Usuario registrado correctamente");
        }

        // ==============================
        // ENDPOINT DE LOGIN
        // POST: api/auth/login
        // ==============================
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            // Busca el usuario por nombre de usuario
            var user = await _users.GetByUserNameAsync(dto.Username);
            if (user == null)
                return Unauthorized("Usuario no encontrado");

            // Verifica que la contraseña sea correcta
            if (!_passwords.Verify(dto.Password, user.PasswordHash))
                return Unauthorized("Contraseña incorrecta");

            // Genera el token JWT con los datos del usuario
            var token = _jwt.Generate(user);

            // Devuelve el token al frontend
            return Ok(new { token });
        }
    }
}
