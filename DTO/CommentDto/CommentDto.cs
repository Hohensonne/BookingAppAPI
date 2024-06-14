namespace DTO.CommentDto;

public class CommentDto
{
    public Guid Id { get; set; }
    
    public Guid IdHotel { get; set; }
    
    public string IdUser { get; set; }
    
    public string Text { get; set; }
    
    public string PositiveText { get; set; }
    
    public string NegativeText { get; set; }
    
    public short ReviewScore { get; set; }
    
    public DateTime CreateDate { get; set; }
    
    public DateTime UpdateDate { get; set; }
}