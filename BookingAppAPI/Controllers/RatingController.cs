using DTO.RatingDto;
using Microsoft.AspNetCore.Authorization; // Установка связи с объектами для транспортировки 
using Microsoft.AspNetCore.Mvc; // Вызов функционала ASPNet для создания запросов
using Service.RatingService; 


namespace BookingAppAPI.Controllers;

[ApiController]
[Route("rating")]
public class RatingController(IRatingService ratingService) : Controller
{
    [HttpGet]
    public JsonResult GetRatings()
    {
        var ratings = ratingService.GetRating();
        return Json(ratings);
    }

    [Route("{id}")]
    [HttpGet]
    public JsonResult GetRating(Guid id)
    {
        var rating = ratingService.GetRating(id);
        return Json(rating);
    }

    [Authorize]
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateRating(UpdateRatingDto dto)
    {
        ratingService.UpdateRating(dto);

        return Json("updated");
    }

    [Authorize]
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteRating(Guid id)
    {
        ratingService.DeleteRating(id);

        return Json("deleted");
    }
    
}