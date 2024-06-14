namespace DTO.CompliantBookDto;

public class CompliantBookDto
{
    public Guid Id { get; set; }
    
    public Guid IdHotel { get; set; }
    
    public string Text { get; set; }

    public DateTime CreateDate { get; set; }
}