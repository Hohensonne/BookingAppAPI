using DTO.RatingDto;

namespace Repository.RatingRepository;

public interface IRatingRepository
{
    RatingDto Get(Guid id);

    List<RatingDto> GetAll();
    
    void Update(UpdateRatingDto dto); 
    void Delete(Guid id); 

}