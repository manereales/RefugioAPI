using AppRefugio.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppRefugio.Controllers
{
    [ApiController]
    [Route("api/cuentas")]
    public class CuentasController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser> signInManager;

        public CuentasController(UserManager<IdentityUser> userManager, IConfiguration configuration, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
        }


        [HttpPost("Registrar")]
        public async Task<ActionResult<RespuestaAutenticacion>> Registrar([FromForm]CredencialesUsuarios credencialesUsuarios)
        {
            var usuario = new IdentityUser { Email = credencialesUsuarios.Email, UserName = credencialesUsuarios.Email };
            var resultado = await userManager.CreateAsync(usuario, credencialesUsuarios.Password);

            if (resultado.Succeeded)
            {
                return CrearToken(credencialesUsuarios);
            }
            else
            {
                return BadRequest(resultado.Errors);
            }
        }



        [HttpPost("login")]
        public async Task<ActionResult<RespuestaAutenticacion>> Login([FromForm] CredencialesUsuarios credencialesUsuarios)
        {
            var usuario = await signInManager.PasswordSignInAsync(credencialesUsuarios.Email, credencialesUsuarios.Password, isPersistent: false, lockoutOnFailure: false);

            if (usuario.Succeeded)
            {
                return CrearToken(credencialesUsuarios);
            }
            else
            {
                return BadRequest("usuario no encontrado");
            }
        }

        private RespuestaAutenticacion CrearToken(CredencialesUsuarios credencialesUsuarios)
        {
            var Claims = new List<Claim>()
            {
                new Claim("email", credencialesUsuarios.Email)
            };

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["llavejwt"]));

            var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

            var expiracion = DateTime.UtcNow.AddDays(1);

            var token = new JwtSecurityToken(issuer: null, audience: null, claims: Claims, expires: expiracion, signingCredentials: creds);

            return new RespuestaAutenticacion()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiracion = expiracion
            };
        }

        

    }
}
