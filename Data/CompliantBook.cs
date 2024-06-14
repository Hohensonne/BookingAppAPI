using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class CompliantBook
{
    public Guid Id { get; set; }
    
    public Guid IdHotel { get; set; }

    public Hotel Hotel { get; set; } = null!;
    
    public string Text { get; set; }

    public DateTime CreateDate { get; set; }
}

public class
    CompliantBookMap
{
    public CompliantBookMap(EntityTypeBuilder<CompliantBook> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);
        entityTypeBuilder.Property(e => e.Text).IsRequired();
        entityTypeBuilder 
            .HasOne(e => e.Hotel)
            .WithMany(e => e.CompliantBooks)
            .HasForeignKey(e => e.IdHotel); 

    }
}