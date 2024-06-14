using Data;
using DTO.UserDto;
using Microsoft.AspNetCore.Identity;

namespace Repository.UserRepository;

public interface IUserRepository
{
    Task<User> Get(string Id);
    Task<List<User>> GetAll(); 
    Task<IdentityResult> Insert(CreateUserDto dto);
    Task<IdentityResult> Update(UpdateUserDto dto);
    Task<IdentityResult> Delete(string email);
}