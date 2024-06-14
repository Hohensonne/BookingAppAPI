using DTO.CommentDto;

namespace Repository.CommentRepository;

public interface ICommentRepository
{
    CommentDto Get(Guid id);

    List<CommentDto> GetAll();
    
    void Insert(CreateCommentDto dto); 
    
    void Update(UpdateCommentDto dto); 
    
    void Delete(Guid id); 
    
    
}