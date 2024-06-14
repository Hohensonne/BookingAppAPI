using Data;
using DTO.MediaDto;
using Repository.MediaRepository;

namespace Service.MediaService;

public class MediaService(IMediaRepository mediaRepository) : IMediaService
{
    private IMediaRepository _mediaRepository = mediaRepository;

    public MediaDto GetMedia(Guid id)
    {
        return _mediaRepository.Get(id);
    }

    public List<MediaDto> GetMedia()
    {
        return _mediaRepository.GetAll();
    }

    public void InsertMedia(CreateMediaDto dto)
    {
        _mediaRepository.Insert(dto);
    }

    public void UpdateMedia(UpdateMediaDto dto)
    {
        _mediaRepository.Update(dto);
    }

    public void DeleteMedia(Guid id)
    {
        _mediaRepository.Delete(id);
    }
    
    public Dictionary<string,int> UploadFileCheck()
    {
        return _mediaRepository.GetMIMEs();
    }
}