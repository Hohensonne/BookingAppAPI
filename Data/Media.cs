using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class Media
{
    public Guid Id { get; set; }

    public string FilePath { get; set; }
    
    public string TableName { get; set; }

    public Guid TableNameEntityId { get; set; }
    
    public Guid IdDataType { get; set; }

    public DataType DataType { get; set; }
}


public class
    MediaMap 
{
    public MediaMap(EntityTypeBuilder<Media> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);
        entityTypeBuilder.Property(e => e.FilePath).IsRequired();
        entityTypeBuilder.Property(e => e.TableNameEntityId).IsRequired();
        entityTypeBuilder.Property(e => e.IdDataType).IsRequired();
        
        entityTypeBuilder                           
            .HasOne(e => e.DataType) 
            .WithMany(e => e.Medias)
            .HasForeignKey(e => e.IdDataType); 

    }
}