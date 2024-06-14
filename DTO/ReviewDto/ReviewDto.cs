namespace DTO.ReviewDto;

public class ReviewDto
{
    public Guid Id { get; set; }
    
    public Guid IdHotel { get; set; }
    
    public string IdUser { get; set; }
    
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