using DTO.ReviewDto;
using Microsoft.AspNetCore.Authorization; // Установка связи с объектами для транспортировки 
using Microsoft.AspNetCore.Mvc; // Вызов функционала ASPNet для создания запросов
using Service.ReviewService; // Установка связи с сервисом книг


namespace BookingAppAPI.Controllers;

[ApiController]
[Route("review")]
public class ReviewController(IReviewService reviewService) : Controller
{
    [HttpGet]
    public JsonResult GetReview()
    {
        var reviews = reviewService.GetReview();
        return Json(reviews);
    }

    [Route("{id}")]
    [HttpGet]
    public JsonResult GetReview(Guid id)
    {
        var review = reviewService.GetReview(id);
        return Json(review);
    }

    [Authorize]
    [Route("create")]
    [HttpPost]
    public JsonResult CreateReview(CreateReviewDto dto)
    {
        reviewService.InsertReview(dto);

        return Json("created");
    }

    [Authorize]
    [Route("update")]
    [HttpPatch] // Тип запроса 
    public JsonResult UpdateReview(UpdateReviewDto dto)
    {
        reviewService.UpdateReview(dto);

        return Json("updated");
    }

    [Authorize]
    [Route("delete/{id}")]
    [HttpDelete] // Тип запроса
    public JsonResult DeleteReview(Guid id)
    {
        reviewService.DeleteReview(id);

        return Json("deleted");
    }
    
}