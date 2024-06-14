using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace Data;

public class User : IdentityUser
{
    public string Gender { get; set; }
    
    public List<Comment> Comments { get; set; } = [];
    public List<Review> Reviews { get; set; } = [];

}


public class
    UserMap
{
    public UserMap(EntityTypeBuilder<User> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);
    }
}