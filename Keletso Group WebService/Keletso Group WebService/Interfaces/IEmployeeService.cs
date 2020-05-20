using Keletso_Group_WebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keletso_Group_WebService.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeModel>> GetAllEmployees();
        Task<EmployeeModel> GetEmployee(int id);
        Task<int> UpdateEmployee(int id, EmployeeModel request);
        Task DeleteEmployee(int id);
        Task<int> CreateEmployee(EmployeeModel request);
    }
}
