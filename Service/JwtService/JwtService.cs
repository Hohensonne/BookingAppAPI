using DTO.AuthDto;
using Microsoft.AspNetCore.Identity;
using Repository.JwtRepository;
namespace Service.JwtService;

public class JwtService (IJwtRepository jwtRepository) : IJwtService
{
    
    private IJwtRepository _jwtRepository = jwtRepository;

    
    public Task<AuthSignInResponse> CreateToken(AuthSignInDto dto)
    {
        return _jwtRepository.CreateToken(dto);
    }

}