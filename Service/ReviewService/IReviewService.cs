using DTO.ReviewDto;

namespace Service.ReviewService;

public interface IReviewService
{
    ReviewDto GetReview(Guid id);
    List<ReviewDto> GetReview();
    void InsertReview(CreateReviewDto dto);
    void UpdateReview(UpdateReviewDto dto);
    void DeleteReview(Guid id);
}