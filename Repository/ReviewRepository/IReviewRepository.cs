using DTO.ReviewDto;

namespace Repository.ReviewRepository;

public interface IReviewRepository
{
    ReviewDto Get(Guid id);

    List<ReviewDto> GetAll();
    
    void Insert(CreateReviewDto dto); 
    
    void Update(UpdateReviewDto dto); 
    
    void Delete(Guid id); 
    
    void SaveChanges();
}