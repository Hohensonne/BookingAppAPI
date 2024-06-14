using Data;
using DTO.UserDto;
using Microsoft.AspNetCore.Identity;

namespace Service.UserService;

public interface IUserService
{
    Task <User> GetUser(string id);
    Task<List<User>> GetUsers();
    Task<IdentityResult> InsertUser(CreateUserDto dto);
    Task<IdentityResult> UpdateUser(UpdateUserDto dto);
    Task<IdentityResult> DeleteUser(string id);
}