using System.ComponentModel.DataAnnotations;

namespace DTO.AuthDto;

public class AuthSignInDto
{
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
}