using DTO.MediaDto;
using Data;


namespace Service.MediaService;

public interface IMediaService
{
    MediaDto GetMedia(Guid id);
    List<MediaDto> GetMedia();
    void InsertMedia(CreateMediaDto dto);
    void UpdateMedia(UpdateMediaDto dto);
    void DeleteMedia(Guid id);
    Dictionary<string,int> UploadFileCheck();
}