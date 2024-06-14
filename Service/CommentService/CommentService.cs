using DTO.CommentDto;
using Repository.CommentRepository;

namespace Service.CommentService;

public class CommentService(ICommentRepository commentRepository) : ICommentService
{
    private ICommentRepository _commentRepository = commentRepository;

    public CommentDto GetComment(Guid id)
    {
        return _commentRepository.Get(id);
    }

    public List<CommentDto> GetComment()
    {
        return _commentRepository.GetAll();
    }

    public void InsertComment(CreateCommentDto dto)
    {
        _commentRepository.Insert(dto);
    }

    public void UpdateComment(UpdateCommentDto dto)
    {
        _commentRepository.Update(dto);
    }

    public void DeleteComment(Guid id)
    {
        _commentRepository.Delete(id);
    }
}