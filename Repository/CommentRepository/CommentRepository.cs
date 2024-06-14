using Data;
using DTO.CommentDto;
using Microsoft.EntityFrameworkCore;

namespace Repository.CommentRepository;

public class CommentRepository(ApplicationContext context) : ICommentRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Comment> _comments = context.Set<Comment>();

    public CommentDto Get(Guid id)
    {
        var comment = _comments.SingleOrDefault(a => a.Id == id);
        if (comment == null) return null;
        return new CommentDto()
        {
            Id = comment.Id,
            IdHotel = comment.IdHotel,
            IdUser = comment.IdUser,
            Text = comment.Text,
            PositiveText = comment.PositiveText,
            NegativeText = comment.NegativeText,
            ReviewScore = comment.ReviewScore,
            CreateDate = comment.CreateDate,
            UpdateDate = comment.UpdateDate
        };
    }
    
    public List<CommentDto> GetAll()
    {
        var comments = _comments.ToList();
        List<CommentDto> lcomments = new List<CommentDto>();

        foreach (var comment in comments)
        {
            lcomments.Add(new CommentDto
            {
                Id = comment.Id,
                IdHotel = comment.IdHotel,
                IdUser = comment.IdUser,
                Text = comment.Text,
                PositiveText = comment.PositiveText,
                NegativeText = comment.NegativeText,
                ReviewScore = comment.ReviewScore,
                CreateDate = comment.CreateDate,
                UpdateDate = comment.UpdateDate
            });
        }
        return lcomments;
    }


    public void Insert(CreateCommentDto dto)
    {
        
        Comment comment = new Comment()
        {
            Id = Guid.NewGuid(),
            IdHotel = dto.IdHotel,
            IdUser = dto.IdUser,
            Text = dto.Text,
            PositiveText = dto.PositiveText,
            NegativeText = dto.NegativeText,
            ReviewScore = dto.ReviewScore,
            CreateDate = DateTime.UtcNow
        };
        _comments.Add(comment);
        context.SaveChangesAsync();
    }

    public void Update(UpdateCommentDto dto)
    {
        var comment = _comments.SingleOrDefault(a => a.Id == dto.Id);
        if (comment == null) return;

        comment.IdHotel = dto.IdHotel;
        comment.IdUser = dto.IdUser;
        comment.Text = dto.Text;
        comment.PositiveText = dto.PositiveText;
        comment.NegativeText = dto.NegativeText;
        comment.ReviewScore = dto.ReviewScore;
        comment.UpdateDate = DateTime.UtcNow;

        _comments.Update(comment);
        context.SaveChangesAsync();
    }
    
    public void Delete(Guid id)
    {
        var comment = _comments.SingleOrDefault(a => a.Id == id);
        if (comment == null) return;
        _comments.Remove(comment);
        context.SaveChangesAsync();
    }
    
}