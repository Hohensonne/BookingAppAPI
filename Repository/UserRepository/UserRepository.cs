using Data;
using DTO.UserDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Repository.UserRepository;

public class UserRepository(UserManager<User> userManager) : IUserRepository
{
    
    public async Task<User> Get(string Id)
    {
        return await userManager.FindByIdAsync(Id);
    }
    
    public async Task<List<User>> GetAll()
    {
        return await userManager.Users.ToListAsync();
    }

    
    
    public async Task<IdentityResult> Insert(CreateUserDto dto)
    {
        var newUser = new User()
        {
            UserName = dto.UserName,
            Email = dto.Email,
            Gender = dto.Gender,
        };
        
        var result = await userManager.CreateAsync(newUser, dto.Password);
        
        return result;
    }

    public async Task<IdentityResult> Update(UpdateUserDto dto)
    {

        var user = await userManager.FindByIdAsync(dto.Id);
        user.UserName = dto.UserName;
        user.Email = dto.Email;
        user.Gender = dto.Gender;
        if (user != null) return await userManager.UpdateAsync(user);
        return null;
    }

    public async Task<IdentityResult> Delete(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user != null) return await userManager.DeleteAsync(user);
        return null;
    }
}