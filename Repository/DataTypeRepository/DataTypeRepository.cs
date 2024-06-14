using Data;
using DTO.DataTypeDto;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

namespace Repository.DataTypeRepository;

public class DataTypeRepository(ApplicationContext context) : IDataTypeRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<DataType> _dataTypes = context.Set<DataType>();

    public DataTypeDto Get(Guid id)
    {
        var dataType = _dataTypes.SingleOrDefault(a => a.Id == id);
        if (dataType == null) return null;
        return new DataTypeDto()
        {
            Id = dataType.Id,
            MIME = dataType.MIME,
            FileExtension = dataType.FileExtension,
            MaxSize = dataType.MaxSize
        };
    }
    
    public List<DataTypeDto> GetAll()
    {
        var dataTypes = _dataTypes.ToList();
        List<DataTypeDto> ldataTypes = new List<DataTypeDto>();

        foreach (var dataType in dataTypes)
        {
            ldataTypes.Add(new DataTypeDto
            {
                Id = dataType.Id,
                MIME = dataType.MIME,
                FileExtension = dataType.FileExtension,
                MaxSize = dataType.MaxSize
                
            });
        }
        return ldataTypes;
    }


    public void Insert(CreateDataTypeDto dto)
    {
        
        
        //FileStream stream = System.IO.File.OpenRead(dto.FilePath);
        //IFormFile file = new FormFile(stream,0, stream.Length, null, Path.GetFileName(stream.Name));
        //
        //var uploadPath = $"{Directory.GetCurrentDirectory()}/DataTypeRepository/DataType";
        //string fullPath = $"{uploadPath}/{file.FileName}";
        //using (var fileStream = new FileStream(fullPath, FileMode.Create))
        //{
        //    await file.CopyToAsync(fileStream);
        //}
        
        
        DataType dataType = new DataType()
        {
            Id = Guid.NewGuid(),
            MIME = dto.MIME,
            FileExtension = dto.FileExtension,
            MaxSize = dto.MaxSize
        }; 
        
        _dataTypes.Add(dataType);
        context.SaveChangesAsync();
    }

    public void Update(UpdateDataTypeDto dto)
    {
        var dataType = _dataTypes.SingleOrDefault(a => a.Id == dto.Id);
        if (dataType == null) return;

        dataType.MIME = dto.MIME;
        dataType.FileExtension = dto.FileExtension;
        dataType.MaxSize = dto.MaxSize;
            

        _dataTypes.Update(dataType);
        context.SaveChangesAsync();
    }
    
    public void Delete(Guid id)
    {
        var dataType = _dataTypes.SingleOrDefault(a => a.Id == id);
        if (dataType == null) return; 
        _dataTypes.Remove(dataType);
        context.SaveChangesAsync();
    }
}