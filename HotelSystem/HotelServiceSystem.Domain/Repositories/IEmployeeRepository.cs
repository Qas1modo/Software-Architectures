using HotelServiceSystem.Domain.Entities;
namespace HotelServiceSystem.Domain.Repositories;

public interface IEmployeeRepository
{
    void Insert(EmployeeEntity employeeEntity);
    void Update(EmployeeEntity updatedEntity);
    void Remove(EmployeeEntity employeeEntity);
}


