using AutoMapper;
using EmpBAL.Dtos;
using EmpDAL.Models;
using EmpDAL.Repository;


namespace EmpBAL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        private IMapper _mapper;

        public DepartmentService(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ServiceResponse<IEnumerable<DepartmentDto>> GetDepartments()
        {
            var response = new ServiceResponse<IEnumerable<DepartmentDto>>();
            var departments = _repository.GetAll();
            if (departments != null && departments.Any())
            {
                response.Data =_mapper.Map<List<DepartmentDto>>(departments);
            }
            else
            {
                response.Success = false;
                response.Message = "No record found!";
            }

            return response;
        }

        public ServiceResponse<DepartmentDto> GetDepartmentById(int departmentId)
        {
            var response = new ServiceResponse<DepartmentDto>();
            var existingDepartment = _repository.GetDepartmentById(departmentId);
            if (existingDepartment != null)
            {
                response.Data = _mapper.Map<Department, DepartmentDto>(existingDepartment);
            }
            else
            {
                response.Success = false;
                response.Message = "No record found!";
            }

            return response;
        }

        public ServiceResponse<string> AddDepartment(DepartmentDto department)
        {
            var response = new ServiceResponse<string>();

            var departmetdetail = _mapper.Map<DepartmentDto, Department>(department);

            var result = _repository.InsertDepartment(departmetdetail);
            if (result)
            {
                response.Message = "Department saved successfully.";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong, please try after sometime.";
            }

            return response;
        }

        public ServiceResponse<string> UpdateDepartment(DepartmentDto department)
        {
            var response = new ServiceResponse<string>();

            var existingDepartment = _repository.GetDepartmentById(department.DepartmentId);
            var result = false;
            if (existingDepartment != null)
            {
                var departmetdetail = _mapper.Map<DepartmentDto,Department>(department);
         
                result = _repository.UpdateDepartment(departmetdetail);
            }

            if (result)
            {
                response.Message = "Department updated successfully.";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong, please try after sometime.";
            }

            return response;
        }

        public ServiceResponse<string> DeleteDepartment(int id)
        {
            var response = new ServiceResponse<string>();
            var result = _repository.DeleteDepartment(id);
            if (result)
            {
                response.Message = "Department deleted successfully.";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong, please try after sometimes.";
            }

            return response;
        }
    }
}
