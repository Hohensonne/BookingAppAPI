using DTO.CompliantBookDto;
using Microsoft.AspNetCore.Authorization; // Установка связи с объектами для транспортировки 
using Microsoft.AspNetCore.Mvc; // Вызов функционала ASPNet для создания запросов
using Service.CompliantBookService; 


namespace BookingAppAPI.Controllers;

[ApiController]
[Route("compliantBook")]
public class CompliantBookController(ICompliantBookService compliantBookService) : Controller
{
    [HttpGet]
    public JsonResult GetCompliantBook()
    {
        var compliantBooks = compliantBookService.GetCompliantBook();
        return Json(compliantBooks);
    }

    [Route("{id}")]
    [HttpGet]
    public JsonResult GetCompliantBook(Guid id)
    {
        var compliantBook = compliantBookService.GetCompliantBook(id);
        return Json(compliantBook);
    }

    [Authorize]
    [Route("create")]
    [HttpPost]
    public JsonResult CreateCompliantBook(CreateCompliantBookDto dto)
    {
        compliantBookService.InsertCompliantBook(dto);

        return Json("created"); 
    }
    
    [Authorize]
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteCompliantBook(Guid id)
    {
        compliantBookService.DeleteCompliantBook(id);

        return Json("deleted");
    }
    
}