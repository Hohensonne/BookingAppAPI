

namespace DTO.DataTypeDto;

public class CreateDataTypeDto
{
    public string MIME { get; set; }
    
    public string FileExtension { get; set; }
    public int MaxSize { get; set; }
}