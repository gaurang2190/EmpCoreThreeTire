using EmpDAL.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpBAL.Services
{
    public static class DependancyResolver
    {
        public static void Dependancy(IServiceCollection services) {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
        }
    }
}
