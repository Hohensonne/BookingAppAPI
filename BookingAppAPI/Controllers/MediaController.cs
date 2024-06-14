using System.Net.Mime;
using DTO.MediaDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.MediaService;


namespace BookingAppAPI.Controllers;

[ApiController]
[Route("media")]
public class MediaController(IMediaService mediaService) : Controller
{
    [HttpGet]
    public JsonResult  GetMedias()
    {
        var medias = mediaService.GetMedia();
        return  Json(medias);
    }

    [Route("{id}")]
    [HttpGet]
    public FileContentResult GetMedia(Guid id)
    {
        var media = mediaService.GetMedia(id);
        return File(media.b, media.MIME);
    }

    [Authorize]
    [Route("create")]
    [HttpPost]
    public Task CreateMedia(CreateMediaDto dto)
    {
        bool flag = false;
        var MIMEs = mediaService.UploadFileCheck();
        foreach (var MIME in MIMEs)
        {
            if (dto.File.FileName.EndsWith(MIME.Key))
            {
                flag = true;

                if (dto.File.Length / 1024 > MIME.Value)
                {
                    return Task.FromException(new InvalidDataException());
                }
                
                break;
            }
        }
        
        
        
        if (flag == true)
        {
            
            
            
            mediaService.InsertMedia(dto);
            return Task.CompletedTask;
        }
        else
        {
            return Task.FromException(new InvalidDataException());

        }

        
    }

    [Authorize]
    [Route("update")]
    [HttpPatch] // Тип запроса 
    public JsonResult UpdateMedia(UpdateMediaDto dto)
    {
        mediaService.UpdateMedia(dto);

        return Json("updated");
    }

    [Authorize]
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteMedia(Guid id)
    {
        mediaService.DeleteMedia(id);

        return Json("deleted");
    }

    
    
    
}