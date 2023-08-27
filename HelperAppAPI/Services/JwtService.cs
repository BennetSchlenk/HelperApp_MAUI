using HelperAppAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HelperAppAPI.Services
{
    public class JwtService
    {
        private int TokenExpiration;

        private readonly IConfiguration _configuration;

        private string JwtIssuer;
        private string JwtAudience;
        private string JwtSubject;
        private string JwtSigningKey;
        private SigningCredentials SigningCredentials;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
            TokenExpiration = _configuration.GetValue("Jwt:TokenExpirtationMinutes", 1);
            JwtIssuer = _configuration.GetValue<string>("Jwt:Issuer")!;
            JwtAudience = _configuration.GetValue<string>("Jwt:Audience")!;
            JwtSubject = _configuration.GetValue<string>("Jwt:Subject")!;
            JwtSigningKey = _configuration.GetValue<string>("Jwt:Key")!;

            Console.WriteLine(JwtSigningKey);

            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSigningKey)), SecurityAlgorithms.HmacSha256Signature);
        }

        public AuthenticationResponse CreateToken(IdentityUser user)
        {
            var expirationDate = DateTime.UtcNow.AddMinutes(TokenExpiration);

            var token = new JwtSecurityToken(JwtIssuer, JwtAudience, CreateClaims(user), DateTime.UtcNow, expirationDate, SigningCredentials);

            var tokenHandler = new JwtSecurityTokenHandler();

            return new AuthenticationResponse { Expiration = expirationDate, Token = tokenHandler.WriteToken(token) };
        }

        private Claim[] CreateClaims(IdentityUser user) =>
    new[] {
                new Claim(JwtRegisteredClaimNames.Sub, JwtSubject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("uid", user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
    };
    }
}
