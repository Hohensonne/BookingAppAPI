

namespace DTO.DataTypeDto;

public class DataTypeDto
{
    public Guid Id { get; set; }
    
    public string MIME { get; set; }
    
    public string FileExtension { get; set; }
    
    public int MaxSize { get; set; }
}