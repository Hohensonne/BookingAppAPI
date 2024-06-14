using Data;
using DTO.UserDto;
using Microsoft.AspNetCore.Identity;
using Repository.UserRepository;

namespace Service.UserService;

public class UserService(IUserRepository userRepository) : IUserService
{

    public async Task<User> GetUser(string id)
    {
        return await userRepository.Get(id);
    }
    public async Task<List<User>> GetUsers()
    {
        return await userRepository.GetAll();
    }
    
    public async Task<IdentityResult> InsertUser(CreateUserDto dto)
    {
        return await userRepository.Insert(dto);
    }

    public async Task<IdentityResult> UpdateUser(UpdateUserDto dto)
    {
        return await userRepository.Update(dto);
    }

    public async Task<IdentityResult> DeleteUser(string id)
    {
        return await userRepository.Delete(id);
    }
}