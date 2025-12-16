using ReservasApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReservasApi.Services
{
    // Servicio que genera tokens JWT válidos.
    // Tokens: Un token es una clave digital (una cadena de texto) que sirve para identificar
    // y autorizar a un usuario, aplicación o acción dentro de un sistema.

    // JWT: es un mecanismo de autenticación que permite identificar y autorizar a un
    // usuario de forma segura, sin guardar sesión en el servidor.
    // JWT (JSON Web Token) tiene 3 partes: HEADER.PAYLOAD.SIGNATURE
    public class JwtService
    {
        public readonly IConfiguration _config;

        public JwtService(IConfiguration config) => _config = config;

        public string Generate(User user)
        {
            //La clave secreta para firmar el token
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            //Esta línea crea las credenciales de firma del token JWT.
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Claims: Información del usario que irá dentro los tokens
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            //Crear el token
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
                );
            {
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            ;
        }
    }
}