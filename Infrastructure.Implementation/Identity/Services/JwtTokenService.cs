using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Infrastructure.Interfaces.Identity.Services;
using Utils.Identity;

namespace Infrastructure.Implementation.Identity.Services
{
    public class JwtTokenService : ITokenService<TokenRequest, TokenResponse>
    {
        private readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenResponse CreateToken(TokenRequest request)
        {
            var claims = CreateClaims(request);
            var credentials = CreateSigningCredentials();
            var expiration = DateTime.Now.AddMinutes(ApplicationIdentityConstants.AccessTokenExpirationMinutes);
            var token = CreateJwtToken(claims, credentials, expiration);

            var tokenHandler = new JwtSecurityTokenHandler();
            var accessToken = tokenHandler.WriteToken(token);

            return new TokenResponse
            {
                UserName = request.UserName,
                FullName = request.FullName,
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

        private Claim[] CreateClaims(TokenRequest request)
        {
            return new[] {
                new Claim(ClaimTypes.NameIdentifier, request.UserId),
                new Claim(ClaimTypes.Name, request.UserName),
                new Claim(ApplicationIdentityConstants.EmployeeIdClaimType, request.EmployeeId.ToString())
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
