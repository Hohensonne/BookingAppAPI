

namespace DTO.DataTypeDto;

public class UpdateDataTypeDto
{
    public Guid Id { get; set; }
    
    public string MIME { get; set; }
    
    public string FileExtension { get; set; }
    public int MaxSize { get; set; }
}