using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class Comment
{
    public Guid Id { get; set; }
    
    public Guid IdHotel { get; set; }

    public Hotel Hotel { get; set; } = null!;
    
    public string IdUser { get; set; }
    public User User { get; set; }
    
    public string Text { get; set; }
    
    public string PositiveText { get; set; }
    
    public string NegativeText { get; set; }
    
    public short ReviewScore { get; set; }
    
    public DateTime CreateDate { get; set; }
    
    public DateTime UpdateDate { get; set; }
}

public class
    CommentMap
{
    public CommentMap(EntityTypeBuilder<Comment> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);
        entityTypeBuilder.Property(e => e.ReviewScore).IsRequired();
        entityTypeBuilder
            .HasOne(e => e.Hotel)
            .WithMany(e => e.Comments)
            .HasForeignKey(e => e.IdHotel);
        entityTypeBuilder.HasKey(e => e.Id);
        entityTypeBuilder.Property(e => e.ReviewScore).IsRequired();
        entityTypeBuilder
            .HasOne(e => e.User)
            .WithMany(e => e.Comments)
            .HasForeignKey(e => e.IdUser);

    }
    
}