using DTO.HotelDto;
using DTO.RatingDto;

namespace Service.ServiceHotel
{
    public interface IServiceHotel
    {
        HotelDto GetHotel(Guid id);
        List<HotelDto> GetHotels();
        void InsertHotel(CreateHotelDto dto);
        void UpdateHotel(UpdateHotelDto dto);
        void DeleteHotel(Guid id);
    }
}
