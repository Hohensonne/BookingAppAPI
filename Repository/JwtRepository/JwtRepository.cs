using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Data;
using DTO.AuthDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Repository.JwtRepository;

public class JwtRepository(
    UserManager<User> userManager
) : IJwtRepository
{
    private const int EXPIRATION_MINUTES = 60;

    private const string KEY = "8b0fa5c39bcc9d22a9d4c8d42ba40fd73c85488b4c43d74b1b26122fe4301700";
    private const string ISSUER = "bookapilan";
    private const string AUDIENCE = "bookapilan";
    private const string SUBJECT = "JWT for bookapi.lan";

    private JwtSecurityToken CreateJwtToken(
        Claim[] claims,
        SigningCredentials credentials,
        DateTime expiration
    ) => new JwtSecurityToken(
        ISSUER,
        AUDIENCE,
        claims,
        expires: expiration,
        signingCredentials: credentials
    );

    private Claim[] CreateClaims(User user) => new[]
    {
        new Claim(JwtRegisteredClaimNames.Sub, SUBJECT),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Email, user.Email),
    };

    private SigningCredentials CreateSigningCredentials() => new SigningCredentials(
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY)),
        SecurityAlgorithms.HmacSha256
    );

    public async Task<AuthSignInResponse> CreateToken(AuthSignInDto dto)
    {
        var user = await userManager.FindByEmailAsync(dto.Email);
        if (user == null) return null;

        var isValidPassword = await userManager.CheckPasswordAsync(user, dto.Password);

        if (!isValidPassword) return null;
        
        var expiration = DateTime.UtcNow.AddMinutes(EXPIRATION_MINUTES);

        var token = CreateJwtToken(
            CreateClaims(user),
            CreateSigningCredentials(),
            expiration
        );

        var tokenHandler = new JwtSecurityTokenHandler();

        return new AuthSignInResponse
        {
            Token = tokenHandler.WriteToken(token),
            Expiration = expiration
        };
    }
}