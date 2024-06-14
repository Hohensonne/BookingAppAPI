using Microsoft.AspNetCore.Http;

namespace DTO.MediaDto;

public class CreateMediaDto
{
    public IFormFile File { get; set; }
    
    public string TableName { get; set; }

    public Guid TableNameEntityId { get; set; }
}