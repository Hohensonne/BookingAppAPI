using DTO.ReviewDto;
using Repository.ReviewRepository;

namespace Service.ReviewService;

public class ReviewService(IReviewRepository reviewRepository) : IReviewService
{
    private IReviewRepository _reviewRepository = reviewRepository;

    public ReviewDto GetReview(Guid id)
    {
        return _reviewRepository.Get(id);
    }

    public List<ReviewDto> GetReview()
    {
        return _reviewRepository.GetAll();
    }

    public void InsertReview(CreateReviewDto dto)
    {
        _reviewRepository.Insert(dto);
    }

    public void UpdateReview(UpdateReviewDto dto)
    {
        _reviewRepository.Update(dto);
    }

    public void DeleteReview(Guid id)
    {
        _reviewRepository.Delete(id);
    }
}