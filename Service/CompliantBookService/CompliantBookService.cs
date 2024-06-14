using DTO.CompliantBookDto;
using Repository.CompliantBookRepository;

namespace Service.CompliantBookService;

public class CompliantBookService(ICompliantBookRepository compliantBookRepository) : ICompliantBookService
{
    private ICompliantBookRepository _compliantBookRepository = compliantBookRepository;

    public CompliantBookDto GetCompliantBook(Guid id)
    {
        return _compliantBookRepository.Get(id);
    }

    public List<CompliantBookDto> GetCompliantBook()
    {
        return _compliantBookRepository.GetAll();
    }

    public void InsertCompliantBook(CreateCompliantBookDto dto)
    {
        _compliantBookRepository.Insert(dto);
    }

    public void DeleteCompliantBook(Guid id)
    {
        _compliantBookRepository.Delete(id);
    }
}