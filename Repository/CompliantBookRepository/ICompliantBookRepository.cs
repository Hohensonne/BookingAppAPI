using DTO.CompliantBookDto;

namespace Repository.CompliantBookRepository;

public interface ICompliantBookRepository
{
    CompliantBookDto Get(Guid id);

    List<CompliantBookDto> GetAll();
    
    void Insert(CreateCompliantBookDto dto); 
    
    void Delete(Guid id); 
}