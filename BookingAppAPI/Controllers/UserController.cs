using Data;
using DTO.UserDto;
using DTO.AuthDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.UserService;
using Service.JwtService;


namespace BookAppAPI.Controllers;

[ApiController]
[Route("users")]
public class UserController(IUserService userService, UserManager<User> _userManager, IJwtService jwtService) : Controller
{
    [Authorize]
    [HttpGet]
    public async Task<JsonResult> GetUsers()
    {
        var users = await userService.GetUsers();
        return Json(users);
    }
    
    [Authorize]
    [Route("{id}")]
    [HttpGet]
    public async Task<JsonResult> GetUser(string id)
    {
        var user = await userService.GetUser(id);
        if (user != null) return Json(user);
        else return Json("Пользователь не найден");
    }
        
    [Route("create")]
    [HttpPost]
    public async Task<JsonResult> CreateUser(CreateUserDto dto)
    {
        var result = await userService.InsertUser(dto);

        return Json(result);
    }
    
    
    
    [Route("update")] 
    [HttpPatch]
    public async Task<JsonResult> UpdateMedia(UpdateUserDto dto)
    {
         

        return Json(await userService.UpdateUser(dto)); 
    }

    [Route("delete/{id}")] 
    [HttpDelete] 
    public async Task<JsonResult> DeleteMedia(string id)
    {
        return Json( await userService.DeleteUser(id));
    }
    
    
    
    [Route("signin")]
    [HttpPost]
    public async Task<ActionResult> SignIn(AuthSignInDto dto)
    {
        var authData = await jwtService.CreateToken(dto);

        if (authData == null) return Json("Пользователь не найден или введен неверный пароль");

        return Json(authData);
    }
}