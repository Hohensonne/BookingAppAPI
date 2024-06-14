using DTO.HotelDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceHotel;
using Microsoft.AspNetCore.Authorization;

namespace BookingAppAPI.Controllers
{
    [ApiController]
    [Route("hotel")]
    public class HotelController(IServiceHotel hotelService) : Controller
    {
        [HttpGet]
        public JsonResult GetHotels()
        {
            var hotels = hotelService.GetHotels();
            return Json(hotels);
        }
        
        
        [Route ("{id}")]
        [HttpGet]
        public JsonResult GetHotel(Guid id) 
        {
            var hotel = hotelService.GetHotel(id);
            return Json(hotel);
        }
        [Authorize]
        [Route("create")]
        [HttpPost]
        public JsonResult CreateHotel(CreateHotelDto dto)
        {
            hotelService.InsertHotel(dto);
            return Json("created");
        }
        [Authorize]
        [Route("update")]
        [HttpPatch]
        public JsonResult UpdateHotel(UpdateHotelDto dto)
        {
            hotelService.UpdateHotel(dto);

            return Json("updated");
        }
        [Authorize]
        [Route("delete/{id}")]
        [HttpDelete]
        public JsonResult DeleteHotel(Guid id)
        {
            hotelService.DeleteHotel(id);

            return Json("deleted");
        }
    }
}
