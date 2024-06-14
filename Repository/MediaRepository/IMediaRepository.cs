using DTO.MediaDto;

namespace Repository.MediaRepository;

public interface IMediaRepository
{
    MediaDto Get(Guid id);

    List<MediaDto> GetAll();
    
    void Insert(CreateMediaDto dto); 
    
    void Update(UpdateMediaDto dto); 
    
    void Delete(Guid id);
    Dictionary<string,int> GetMIMEs();
}