using Data;
using DTO.RatingDto;
using Microsoft.EntityFrameworkCore;

namespace Repository.RatingRepository;

public class RatingRepository(ApplicationContext context) : IRatingRepository
{
     private readonly ApplicationContext _context = context;
    private DbSet<Rating> _ratings = context.Set<Rating>();
    private DbSet<Comment> _comments = context.Set<Comment>();
    private DbSet<Review> _reviews = context.Set<Review>();


    public RatingDto Get(Guid id)
    {
        var rating = _ratings.SingleOrDefault(a => a.Id == id);
        if (rating == null) return null;
        return new RatingDto() 
        {
            Id = rating.Id,
            IdHotel = rating.IdHotel,
            StarRating = rating.StarRating,
            GuestRating = rating.GuestRating
        };  
    }
    
    public List<RatingDto> GetAll()
    {
        var ratings = _ratings.ToList();
        List<RatingDto> lratings = new List<RatingDto>();

        foreach (var rating in ratings)
        {
            lratings.Add(new RatingDto
            {
                Id = rating.Id,
                IdHotel = rating.IdHotel,
                StarRating = rating.StarRating,
                GuestRating = rating.GuestRating
            });
        }
        return lratings;
    }
    
    public void Update(UpdateRatingDto dto)
    {
        var comments = _comments.ToList();
        var reviews = _reviews.ToList();
        var rating = _ratings.SingleOrDefault(a => a.Id == dto.Id);
        if (rating == null) return;
        double tmp = 0;
        double tmp1 = 0;
        double avg = 0;
        int count = 0;

        foreach (var comment in comments)
        {
            if (dto.Id == comment.IdHotel)
            {
            tmp += comment.ReviewScore;
            count += 1;
            }
        }

        if (count != 0)
        {
            avg = tmp / count;
            tmp = 0;
            count = 0;
        }

        foreach (var review in reviews)
        {
            if (dto.Id == review.IdHotel)
            {
                tmp1 += review.StuffParamParam;
                tmp1 += review.FacilitiesParam;
                tmp1 += review.CleaniessParam;
                tmp1 += review.ComfortParam;
                tmp1 += review.ValueForMoneyParam;
                tmp1 += review.LocationParam;
                tmp1 += review.FreeWiFiParam;
                tmp += tmp1 / 7;
                count += 1;
            }
        }

        if (count != 0)
        {
            avg += tmp / count;
            avg = avg / 2;
        }
        rating.StarRating = dto.StarRating;
        
        if (avg != 0)
        {
            rating.GuestRating = avg;
        }
        

        _ratings.Update(rating);
        context.SaveChangesAsync();
    }
    
    public void Delete(Guid id)
    {
        var rating = _ratings.SingleOrDefault(a => a.Id == id);
        if (rating == null) return;
        _ratings.Remove(rating);
        context.SaveChangesAsync();
    }
}