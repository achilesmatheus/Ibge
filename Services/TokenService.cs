using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IbgeApi.Models;
using Microsoft.IdentityModel.Tokens;
using IbgeApi.Configurations;
using IbgeApi.Models;
using IbgeApi.ValueObjects;

namespace IbgeApi.Services;

public class TokenService
{
    public string GenerateToken(UserModel user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(JwtConfiguration.JwtKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(GetClaims(user)),
            Expires = DateTime.UtcNow.AddHours(12),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    private IEnumerable<Claim> GetClaims(UserModel user)
    {
        var result = new List<Claim>
        {
            new(ClaimTypes.Email, user.Email.EmailAddress)
        };
        // result.AddRange(
        //     user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name))
        // );
        return result;
    }
}