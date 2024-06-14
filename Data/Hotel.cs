using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class Hotel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
    public List<Comment> Comments { get; set; } = [];
    public List<Review> Reviews { get; set; } = [];
    public List<CompliantBook> CompliantBooks { get; set; } = [];
    public Rating Rating { get; set; }

}

public class 
    HotelMap
{
    public HotelMap(EntityTypeBuilder<Hotel> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);
    }
}
