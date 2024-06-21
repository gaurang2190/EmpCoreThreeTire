using EmpDAL.Models;
using Microsoft.EntityFrameworkCore;


namespace EmpDAL.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmpDbContext _dbContext;

        public DepartmentRepository(EmpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Department> GetAll()
        {
            List<Department> departments = _dbContext.Departments.ToList();
            return departments;
        }

        public bool InsertDepartment(Department department)
        {
            var result = false;
            if (department != null)
            {
                _dbContext.Departments.Add(department);
                _dbContext.SaveChanges();
                result = true;
            }

            return result;
        }

        public bool UpdateDepartment(Department department)
        {
            var result = false;
            if (department != null)
            {
                _dbContext.Entry(department).State = EntityState.Modified;
                _dbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool DeleteDepartment(int id)
        {
            var result = false;
            var category = _dbContext.Departments.Find(id);
            if (category != null)
            {
                _dbContext.Departments.Remove(category);
                _dbContext.SaveChanges();
                result = true;
            }

            return result;
        }

        public Department? GetDepartmentById(int id)
        {
            var department = _dbContext.Departments.AsNoTracking().FirstOrDefault(c => c.DepartmentId == id);
            
            return department;
        }
    }
}
