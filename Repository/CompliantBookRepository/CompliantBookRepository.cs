using Data;
using DTO.CompliantBookDto;
using Microsoft.EntityFrameworkCore;

namespace Repository.CompliantBookRepository;

public class CompliantBookRepository(ApplicationContext context) : ICompliantBookRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<CompliantBook> _compliantBooks = context.Set<CompliantBook>();

    public CompliantBookDto Get(Guid id)
    {
        var compliantBook = _compliantBooks.SingleOrDefault(a => a.Id == id);
        if (compliantBook == null) return null;
        return new CompliantBookDto()
        {
            Id = compliantBook.Id,
            IdHotel = compliantBook.IdHotel,
            Text = compliantBook.Text,
            CreateDate = compliantBook.CreateDate,
        };
    }
    
    public List<CompliantBookDto> GetAll()
    {
        var compliantBooks = _compliantBooks.ToList();
        List<CompliantBookDto> lcompliantBooks = new List<CompliantBookDto>();

        foreach (var compliantBook in compliantBooks)
        {
            lcompliantBooks.Add(new CompliantBookDto
            {
                Id = compliantBook.Id,
                IdHotel = compliantBook.IdHotel,
                Text = compliantBook.Text,
                CreateDate = compliantBook.CreateDate,
            });
        }
        return lcompliantBooks;
    }


    public void Insert(CreateCompliantBookDto dto)
    {
        CompliantBook compliantBook = new CompliantBook()
        {
            Id = Guid.NewGuid(),
            IdHotel = dto.IdHotel,
            Text = dto.Text,
            CreateDate = DateTime.UtcNow
        };
        _compliantBooks.Add(compliantBook);
        context.SaveChangesAsync();
    }
    
    public void Delete(Guid id)
    {
        var compliantBook = _compliantBooks.SingleOrDefault(a => a.Id == id); 
        if (compliantBook == null) return; 
        _compliantBooks.Remove(compliantBook); 
        context.SaveChangesAsync(); 
    }
    
}