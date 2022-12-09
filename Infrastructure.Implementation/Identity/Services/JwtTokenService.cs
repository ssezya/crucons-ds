using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Infrastructure.Interfaces.Identity.Services;
using Infrastructure.Implementation.Identity.Models;
using Utils.Identity;

namespace Infrastructure.Implementation.Identity.Services
{
    public class JwtTokenService : ITokenService<ApplicationIdentityUser, TokenResponse>
    {
        private readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenResponse CreateToken(ApplicationIdentityUser user)
        {
            var claims = CreateClaims(user);
            var credentials = CreateSigningCredentials();
            var expiration = DateTime.Now.AddMinutes(ApplicationIdentityConstants.AccessTokenExpirationMinutes);
            var token = CreateJwtToken(claims, credentials, expiration);

            var tokenHandler = new JwtSecurityTokenHandler();
            var accessToken = tokenHandler.WriteToken(token);

            return new TokenResponse
            {
                AccessToken = accessToken
            };
        }

        private JwtSecurityToken CreateJwtToken(Claim[] claims, SigningCredentials credentials, DateTime expiration)
        {
            return new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expiration,
                signingCredentials: credentials
            );
        }

        private Claim[] CreateClaims(ApplicationIdentityUser user)
        {
            return new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName)
            };
        }

        private SigningCredentials CreateSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            return new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256
            );
        }
    }
}
