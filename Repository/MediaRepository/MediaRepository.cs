using Data;
using DTO.MediaDto;
using Microsoft.EntityFrameworkCore;

namespace Repository.MediaRepository;

public class MediaRepository(ApplicationContext context) : IMediaRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Media> _medias = context.Set<Media>();
    private DbSet<DataType> _dataTypes = context.Set<DataType>();

    public MediaDto Get(Guid id)
    {
        var media = _medias.SingleOrDefault(a => a.Id == id);
        if (media == null) return null;
        
        var dataTypes = _dataTypes.ToList();
        string MIME = "";
        foreach (var dataType in dataTypes)
        {
            if (media.IdDataType == dataType.Id)
            {
                MIME = dataType.MIME;
                break;
            }
        }
        
        byte [] b = System.IO.File.ReadAllBytes(media.FilePath);
        return new MediaDto()
        {
            Id = media.Id,
            FileName = media.FilePath.Substring(media.FilePath.LastIndexOf("\\")),
            TableName = media.TableName,
            TableNameEntityId = media.TableNameEntityId,
            MIME = MIME,
            b = b
        }; 
        
    }
    
    public List<MediaDto> GetAll()  // Получение всех авторов из БД
    {
        var medias = _medias.ToList(); 
        List<MediaDto> lmedias = new List<MediaDto>(); 
        var dataTypes = _dataTypes.ToList();
        foreach (var media in medias) 
        { 
            string MIME = "";
            foreach (var dataType in dataTypes)
            {
                if (media.IdDataType == dataType.Id)
                {
                    MIME = dataType.MIME;
                    break;
                }
            }
            
            lmedias.Add(new MediaDto
            {
                Id = media.Id,
                FileName = media.FilePath.Substring(media.FilePath.LastIndexOf(@"\")+2),
                TableName = media.TableName,
                TableNameEntityId = media.TableNameEntityId,
                MIME = MIME,
            }); 
        }
        return lmedias; 
    }


    public void Insert(CreateMediaDto dto)
    {
        var file = dto.File;
        
        var dataTypes = _dataTypes.ToList();
        
        
        //string mimeType = MimeTypeMap.GetExtension(file.FileName);
        Guid IdDataType = Guid.Empty;
        foreach (var dataType in dataTypes)
        {
            if (file.FileName.EndsWith(dataType.FileExtension))
            {
                IdDataType = dataType.Id;
                break;
            }
           
        }

        
        var uploadPath = "Media";
        string fullPath = $"{uploadPath}\\{file.FileName}";
        using (var fileStream = new FileStream(fullPath, FileMode.Create))
        {
            file.CopyToAsync(fileStream);
        }
        
        
        
        
        Media media = new Media()
        {
            Id = Guid.NewGuid(),
            FilePath = fullPath,
            TableName = dto.TableName,
            TableNameEntityId = dto.TableNameEntityId,
            IdDataType = IdDataType
        }; 
        
        _medias.Add(media);
        context.SaveChangesAsync();
    }

    public void Update(UpdateMediaDto dto)
    {
        var media = _medias.SingleOrDefault(a => a.Id == dto.Id);
        if (media == null) return;
        
        var file = dto.File;
        
        var dataTypes = _dataTypes.ToList();
        
        
        //string mimeType = MimeTypeMap.GetExtension(file.FileName);
        Guid IdDataType = Guid.Empty;
        foreach (var dataType in dataTypes)
        {
            if (file.FileName.EndsWith(dataType.MIME))
            {
                IdDataType = dataType.Id;
                break;
            }
           
        }

        
        var uploadPath = "Media";
        string fullPath = $"{uploadPath}\\{file.FileName}";
        using (var fileStream = new FileStream(fullPath, FileMode.Create))
        {
            file.CopyToAsync(fileStream);
        }


        File.Delete(media.FilePath);
        

        media.Id = Guid.NewGuid();
        media.FilePath = fullPath;
        media.TableName = dto.TableName;
        media.TableNameEntityId = dto.TableNameEntityId;
        media.IdDataType = IdDataType;

        _medias.Update(media);
        context.SaveChangesAsync();
    }
    
    public void Delete(Guid id) 
    {
        var media = _medias.SingleOrDefault(a => a.Id == id);
        if (media == null) return;
        
        File.Delete(media.FilePath);
        
        _medias.Remove(media);
        context.SaveChangesAsync();
    }
    

    public Dictionary<string,int> GetMIMEs()
    {
        var dataTypes = _dataTypes.ToList();
        var MIMEs = new Dictionary<string,int>();
        foreach (var dataType in dataTypes)
        {
            MIMEs.Add(dataType.FileExtension, dataType.MaxSize);
        }
        return MIMEs;
    }
}