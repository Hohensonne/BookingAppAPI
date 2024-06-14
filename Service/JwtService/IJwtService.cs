using DTO.AuthDto;

namespace Service.JwtService;

public interface IJwtService
{
    Task<AuthSignInResponse> CreateToken(AuthSignInDto dto);
}