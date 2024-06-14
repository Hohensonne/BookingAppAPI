using DTO.RatingDto;

namespace Service.RatingService;

public interface IRatingService
{
    RatingDto GetRating(Guid id);
    List<RatingDto> GetRating();
    void UpdateRating(UpdateRatingDto dto);
    void DeleteRating(Guid id);
}