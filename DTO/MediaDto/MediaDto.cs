

using Microsoft.AspNetCore.Http;

namespace DTO.MediaDto;

public class MediaDto
{
    public Guid Id { get; set; }

    public string FileName { get; set; }
    
    public string TableName { get; set; }

    public Guid TableNameEntityId { get; set; }
    
    public string MIME { get; set; }

    public byte [] b { get; set; }
}