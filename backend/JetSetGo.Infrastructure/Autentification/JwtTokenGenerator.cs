using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JetSetGo.Application.Common.Interfaces.Autentification;
using JetSetGo.Application.Common.Services;
using JetSetGo.Domain.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JetSetGo.Infrastructure.Autentification;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
    {
        _dateTimeProvider = dateTimeProvider;
        this._jwtSettings = jwtOptions.Value;
    }

    public string GenerateToken(Guid userID, string firstName, string secondName,string email,UserRole role)
    {

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(CustomClaimTypes.GivenName, firstName),
            new Claim(CustomClaimTypes.FamilyName, secondName),
            new Claim(CustomClaimTypes.Email, email),
            new Claim(CustomClaimTypes.Role, role.ToString()),
            new Claim(CustomClaimTypes.Subject, userID.ToString()),
           // new Claim(CustomClaimTypes.Subject, userID.ToString()),
        };
        var securityToken = new JwtSecurityToken(
            issuer:_jwtSettings.Issuer,
            audience:_jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
            claims: claims,
            signingCredentials:signingCredentials);
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
    
}