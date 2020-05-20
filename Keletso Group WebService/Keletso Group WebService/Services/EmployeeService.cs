using Keletso_Group_WebService.Entities;
using Keletso_Group_WebService.Interfaces;
using Keletso_Group_WebService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keletso_Group_WebService.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppContext context;

        public EmployeeService(AppContext _context)
        {
            context = _context;
        }

        public async Task<List<EmployeeModel>> GetAllEmployees()
        {
            var employees = await context.Employees.ToListAsync();

            var employeeList = new List<EmployeeModel>();

            foreach (var employee in employees)
            {
                employeeList.Add(new EmployeeModel
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Designation = employee.Designation
                });
            }

            return employeeList;
        }

        public async Task<EmployeeModel> GetEmployee(int id)
        {
            var employee = await context.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();

            return new EmployeeModel
            {
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Designation = employee.Designation
            };
        }

        public async Task<int> UpdateEmployee(int id,EmployeeModel request)
        {
            var employee = await context.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (employee == null)
            {
                throw new ArgumentNullException("Employee does not exist");
            }

            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.Designation = request.Designation;

            await context.SaveChangesAsync();

            return employee.Id;
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await context.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (employee == null)
            {
                throw new ArgumentNullException("Employee does not exist");
            }

            employee.Deleted = true;

            await context.SaveChangesAsync();
        }

        public async Task<int> CreateEmployee(EmployeeModel request)
        {
            var entity = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Designation = request.Designation               
            };

            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity.Id;
        }
    }
}
