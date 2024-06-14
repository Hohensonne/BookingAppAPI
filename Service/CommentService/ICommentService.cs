using DTO.CommentDto;

namespace Service.CommentService;

public interface ICommentService
{
    CommentDto GetComment(Guid id);
    List<CommentDto> GetComment();
    void InsertComment(CreateCommentDto dto);
    void UpdateComment(UpdateCommentDto dto);
    void DeleteComment(Guid id);
}