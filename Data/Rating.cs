using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class Rating
{
    public Guid Id { get; set; }
    
    public Guid IdHotel { get; set; }
    
    public Hotel Hotel { get; set; } = null!;
    
    public short StarRating { get; set; }
    
    public double GuestRating { get; set; }
}


public class
    RatingMap 
{
    public RatingMap(EntityTypeBuilder<Rating> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id); 
        entityTypeBuilder.Property(e => e.GuestRating).IsRequired();
        entityTypeBuilder.Property(e => e.StarRating).IsRequired();
        
        entityTypeBuilder
            .HasOne(e => e.Hotel)
            .WithOne(e => e.Rating)
            .HasForeignKey<Rating>(e => e.IdHotel)
            .IsRequired();
    }
        
}