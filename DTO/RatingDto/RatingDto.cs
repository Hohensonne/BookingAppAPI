namespace DTO.RatingDto;

public class RatingDto
{
    public Guid Id { get; set; }
    
    public Guid IdHotel { get; set; }
    
    public short StarRating { get; set; }
    
    public double GuestRating { get; set; }
}