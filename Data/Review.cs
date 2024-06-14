using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class Review
{
    public Guid Id { get; set; }
    public Guid IdHotel { get; set; }

    public Hotel Hotel { get; set; } = null!;
    
    public string IdUser { get; set; }
    public User User { get; set; }
    
    public string Text { get; set; }
    
    public short StuffParamParam { get; set; }
    
    public short FacilitiesParam { get; set; }
    
    public short CleaniessParam { get; set; }
    
    public short ComfortParam { get; set; }
    
    public short ValueForMoneyParam { get; set; }
    
    public short LocationParam { get; set; }
    
    public short FreeWiFiParam { get; set; }
    
    public DateTime CreateDate { get; set; }
    
    public DateTime UpdateDate { get; set; }
}

public class
    ReviewMap 
{
    public ReviewMap(EntityTypeBuilder<Review> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id); 
        entityTypeBuilder.Property(e => e.Text).IsRequired();
        entityTypeBuilder.Property(e => e.StuffParamParam).IsRequired();
        entityTypeBuilder.Property(e => e.FacilitiesParam).IsRequired();
        entityTypeBuilder.Property(e => e.CleaniessParam).IsRequired();
        entityTypeBuilder.Property(e => e.ComfortParam).IsRequired();
        entityTypeBuilder.Property(e => e.ValueForMoneyParam).IsRequired();
        entityTypeBuilder.Property(e => e.LocationParam).IsRequired();
        entityTypeBuilder.Property(e => e.FreeWiFiParam).IsRequired();
        
        entityTypeBuilder
            .HasOne(e => e.Hotel)
            .WithMany(e => e.Reviews)
            .HasForeignKey(e => e.IdHotel); 
        entityTypeBuilder
            .HasOne(e => e.User)
            .WithMany(e => e.Reviews)
            .HasForeignKey(e => e.IdUser);

    }
}