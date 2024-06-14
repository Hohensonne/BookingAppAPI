using DTO.CompliantBookDto;

namespace Service.CompliantBookService;

public interface ICompliantBookService
{
    CompliantBookDto GetCompliantBook(Guid id);
    List<CompliantBookDto> GetCompliantBook();
    void InsertCompliantBook(CreateCompliantBookDto dto);
    void DeleteCompliantBook(Guid id);
}