using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class DataType
{
    public Guid Id { get; set; }
    
    public string MIME { get; set; }
    
    public string FileExtension { get; set; }
    public int MaxSize { get; set; }
    public List<Media> Medias { get; set; } = [];
}




public class
    DataTypeMap
{
    public DataTypeMap(EntityTypeBuilder<DataType> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id); 
    }
}