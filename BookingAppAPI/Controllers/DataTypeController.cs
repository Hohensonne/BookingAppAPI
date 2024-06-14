using DTO.DataTypeDto;
using Microsoft.AspNetCore.Authorization; // Установка связи с объектами для транспортировки 
using Microsoft.AspNetCore.Mvc; // Вызов функционала ASPNet для создания запросов
using Service.DataTypeService;


namespace BookingAppAPI.Controllers;

[ApiController]
[Route("datatype")]
public class DataTypeController(IDataTypeService dataTypeService) : Controller
{
    [Authorize]
    [HttpGet]
    public JsonResult GetDataTypes()
    {
        var dataTypes = dataTypeService.GetDataType();
        return Json(dataTypes);
    }

    [Authorize]
    [Route("{id}")]
    [HttpGet]
    public JsonResult GetDataType(Guid id)
    {
        var dataType = dataTypeService.GetDataType(id);
        return Json(dataType);
    }
    
    [Authorize]
    [Route("create")]
    [HttpPost]
    public JsonResult CreateDataType(CreateDataTypeDto dto)
    {
        dataTypeService.InsertDataType(dto);
        return Json("created");
    }

    [Authorize]
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateDataType(UpdateDataTypeDto dto)
    {
        dataTypeService.UpdateDataType(dto);

        return Json("updated");
    }

    [Authorize]
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteDataType(Guid id)
    {
        dataTypeService.DeleteDataType(id);

        return Json("deleted");
    }
    
}