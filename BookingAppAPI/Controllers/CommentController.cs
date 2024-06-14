using DTO.CommentDto;
using Microsoft.AspNetCore.Authorization; // Установка связи с объектами для транспортировки 
using Microsoft.AspNetCore.Mvc; // Вызов функционала ASPNet для создания запросов
using Service.CommentService; 


namespace BookingAppAPI.Controllers;

[ApiController]
[Route("comment")]
public class CommentController(ICommentService commentService) : Controller
{
    [HttpGet]
    public JsonResult GetComment()
    {
        var comments = commentService.GetComment();
        return Json(comments);
    }

    [Route("{id}")]
    [HttpGet] 
    public JsonResult GetComment(Guid id)
    {
        var comment = commentService.GetComment(id);
        return Json(comment);
    }
    
    [Authorize]
    [Route("create")]
    [HttpPost]
    public JsonResult CreateComment(CreateCommentDto dto)
    {
        commentService.InsertComment(dto);

        return Json("created");
    }
    
    [Authorize]
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateComment(UpdateCommentDto dto)
    {
        commentService.UpdateComment(dto);

        return Json("updated");
    }
    
    [Authorize]
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteComment(Guid id)
    {
        commentService.DeleteComment(id);

        return Json("deleted");
    }
    
}