using DTO.DataTypeDto;

namespace Service.DataTypeService;

public interface IDataTypeService
{
    DataTypeDto GetDataType(Guid id);
    List<DataTypeDto> GetDataType();
    void InsertDataType(CreateDataTypeDto dto);
    void UpdateDataType(UpdateDataTypeDto dto);
    void DeleteDataType(Guid id);
}