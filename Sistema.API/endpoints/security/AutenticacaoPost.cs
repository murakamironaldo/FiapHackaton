using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.IdentityModel.Tokens;
using Sistema.Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sistema.API.endpoints.security
{
    /// <summary>
    /// Autenticação do usuário
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server error</response>
    public class AutenticacaoPost
    {
        public static string Template => "/autenticacao";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        [AllowAnonymous]
        public static async Task<IResult> Action(
            LoginRequest loginRequest,
            IUsuarioApp usuarioApp,
            IConfiguration configuration,
            IWebHostEnvironment environment
        )
        {
            //log.LogInformation("Getting token");

            var user = usuarioApp.VerificaSenha(loginRequest.Usuario, loginRequest.Senha);

            if (user.Result == null)
            {
                return Results.BadRequest(new { isFaulted = true, exception = "Dados de acesso inválidos." });
            }

            //var claims = await userManager.GetClaimsAsync(user);
            var subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Email, user.Result.Email),
                new(ClaimTypes.NameIdentifier, user.Result.Id.ToString()),
                new(ClaimTypes.Name, user.Result.Nome)

            });
            //subject.AddClaims(claims);

            var key = Encoding.ASCII.GetBytes(configuration["JwtBearerTokenSettings:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                SigningCredentials =
                    new SigningCredentials(
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = configuration["JwtBearerTokenSettings:Audience"],
                Issuer = configuration["JwtBearerTokenSettings:Issuer"],
                Expires = environment.IsDevelopment() || environment.IsStaging()
                    ? DateTime.UtcNow.AddYears(1)
                    : DateTime.UtcNow.AddMinutes(2)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Results.Ok(new
            {
                isFaulted = false,
                token = tokenHandler.WriteToken(token)

            });
        }
    }
}
