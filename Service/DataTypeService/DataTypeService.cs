using DTO.DataTypeDto;
using Repository.DataTypeRepository;

namespace Service.DataTypeService;

public class DataTypeService(IDataTypeRepository dataTypeRepository) : IDataTypeService
{
    private IDataTypeRepository _dataTypeRepository = dataTypeRepository;

    public DataTypeDto GetDataType(Guid id)
    {
        return _dataTypeRepository.Get(id);
    }

    public List<DataTypeDto> GetDataType()
    {
        return _dataTypeRepository.GetAll();
    }

    public void InsertDataType(CreateDataTypeDto dto)
    {
        _dataTypeRepository.Insert(dto);
    }

    public void UpdateDataType(UpdateDataTypeDto dto)
    {
        _dataTypeRepository.Update(dto);
    }

    public void DeleteDataType(Guid id)
    {
        _dataTypeRepository.Delete(id);
    }
}