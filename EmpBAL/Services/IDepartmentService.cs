using EmpBAL.Dtos;
using EmpDAL.Models;

namespace EmpBAL.Services
{
    public interface IDepartmentService
    {
        ServiceResponse<IEnumerable<DepartmentDto>> GetDepartments();

        ServiceResponse<DepartmentDto> GetDepartmentById(int departmentId);

        ServiceResponse<string> AddDepartment(DepartmentDto department);

        public ServiceResponse<string> UpdateDepartment(DepartmentDto department);

        ServiceResponse<string> DeleteDepartment(int id);

    }
}
