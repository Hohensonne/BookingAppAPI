using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Repository;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : IdentityUserContext<IdentityUser>(options)
{ 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new CommentMap(modelBuilder.Entity<Comment>());
        new HotelMap(modelBuilder.Entity<Hotel>());
        new ReviewMap(modelBuilder.Entity<Review>());
        new CompliantBookMap(modelBuilder.Entity<CompliantBook>());
        new RatingMap(modelBuilder.Entity<Rating>());
        new MediaMap(modelBuilder.Entity<Media>());
        new DataTypeMap(modelBuilder.Entity<DataType>());

    }
}