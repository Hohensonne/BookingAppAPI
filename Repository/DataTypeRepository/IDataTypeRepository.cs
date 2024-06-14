using DTO.DataTypeDto;

namespace Repository.DataTypeRepository;

public interface IDataTypeRepository
{
    DataTypeDto Get(Guid id);

    List<DataTypeDto> GetAll();
    
    void Insert(CreateDataTypeDto dto); 
    
    void Update(UpdateDataTypeDto dto); 
    
    void Delete(Guid id); 
}