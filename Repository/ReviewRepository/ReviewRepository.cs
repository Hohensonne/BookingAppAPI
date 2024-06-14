using Data;
using DTO.ReviewDto;
using Microsoft.EntityFrameworkCore;

namespace Repository.ReviewRepository;

public class ReviewRepository(ApplicationContext context) : IReviewRepository
{
     private readonly ApplicationContext _context = context;  // Подключение связи между моделями для корректной работы методов репозитория
    private DbSet<Review> _reviews = context.Set<Review>(); // Получение списка авторов из БД

    public ReviewDto Get(Guid id) // Получение одного автора из БД
    {
        var review = _reviews.SingleOrDefault(a => a.Id == id); // Нахождение автора по его ID в общем списке
        if (review == null) return null; // Если автора не существует
        return new ReviewDto()  // Создание и вывод объекта длч передачи данных найденного автора  
        {
            Id = review.Id,
            IdHotel = review.IdHotel,
            IdUser = review.IdUser,
            Text = review.Text,
            StuffParamParam = review.StuffParamParam,
            FacilitiesParam = review.FacilitiesParam,
            CleaniessParam = review.CleaniessParam,
            ComfortParam = review.ComfortParam,
            ValueForMoneyParam = review.ValueForMoneyParam,
            LocationParam = review.LocationParam,
            FreeWiFiParam = review.FreeWiFiParam,
            CreateDate = review.CreateDate,
            UpdateDate = review.UpdateDate
        };
    }
    
    public List<ReviewDto> GetAll()
    {
        var reviews = _reviews.ToList();
        List<ReviewDto> lreviews = new List<ReviewDto>();

        foreach (var review in reviews)
        {
            lreviews.Add(new ReviewDto
            {
                Id = review.Id,
                IdHotel = review.IdHotel,
                IdUser = review.IdUser,
                Text = review.Text,
                StuffParamParam = review.StuffParamParam,
                FacilitiesParam = review.FacilitiesParam,
                CleaniessParam = review.CleaniessParam,
                ComfortParam = review.ComfortParam,
                ValueForMoneyParam = review.ValueForMoneyParam,
                LocationParam = review.LocationParam,
                FreeWiFiParam = review.FreeWiFiParam,
                CreateDate = review.CreateDate,
                UpdateDate = review.UpdateDate
            });
        }
        return lreviews;
    }


    public void Insert(CreateReviewDto dto)
    {
        Review review = new Review()
        {
            Id = Guid.NewGuid(),
            IdHotel = dto.IdHotel,
            IdUser = dto.IdUser,
            Text = dto.Text,
            StuffParamParam = dto.StuffParamParam,
            FacilitiesParam = dto.FacilitiesParam,
            CleaniessParam = dto.CleaniessParam,
            ComfortParam = dto.ComfortParam,
            ValueForMoneyParam = dto.ValueForMoneyParam,
            LocationParam = dto.LocationParam,
            FreeWiFiParam = dto.FreeWiFiParam,
            CreateDate = DateTime.UtcNow
        };
        _reviews.Add(review);
        context.SaveChangesAsync();
    }

    public void Update(UpdateReviewDto dto)
    {
        var review = _reviews.SingleOrDefault(a => a.Id == dto.Id);
        if (review == null) return;

        review.IdHotel = dto.IdHotel;
        review.IdUser = dto.IdUser;
        review.Text = dto.Text;
        review.StuffParamParam = dto.StuffParamParam;
        review.FacilitiesParam = dto.FacilitiesParam;
        review.CleaniessParam = dto.CleaniessParam;
        review.ComfortParam = dto.ComfortParam;
        review.ValueForMoneyParam = dto.ValueForMoneyParam;
        review.LocationParam = dto.LocationParam;
        review.FreeWiFiParam = dto.FreeWiFiParam;
        review.UpdateDate = DateTime.UtcNow;

        _reviews.Update(review);
        context.SaveChangesAsync();
    }
    
    public void Delete(Guid id)
    {
        var review = _reviews.SingleOrDefault(a => a.Id == id);
        if (review == null) return;
        _reviews.Remove(review);
        context.SaveChanges(); 
    }

    public void SaveChanges()
    {
        context.SaveChangesAsync();
    }
}