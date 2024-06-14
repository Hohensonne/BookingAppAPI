using DTO.RatingDto;
using Repository.RatingRepository;

namespace Service.RatingService;

public class RatingService(IRatingRepository ratingRepository) : IRatingService
{
    private IRatingRepository _ratingRepository = ratingRepository;

    public RatingDto GetRating(Guid id)
    {
        return _ratingRepository.Get(id);
    }

    public List<RatingDto> GetRating()
    {
        return _ratingRepository.GetAll();
    }

    public void UpdateRating(UpdateRatingDto dto)
    {
        _ratingRepository.Update(dto);
    }

    public void DeleteRating(Guid id)
    {
        _ratingRepository.Delete(id);
    }
}