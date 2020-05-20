using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keletso_Group_WebService.Interfaces;
using Keletso_Group_WebService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Keletso_Group_WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<IEnumerable<EmployeeModel>> Get()
        {
            return await employeeService.GetAllEmployees();
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<EmployeeModel> Get(int id)
        {
            return await employeeService.GetEmployee(id);
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<int> Post([FromBody] EmployeeModel request)
        {
           return await employeeService.CreateEmployee(request);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public async Task<int> Put(int id, [FromBody] EmployeeModel request)
        {
            return await employeeService.UpdateEmployee(id, request);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await employeeService.DeleteEmployee(id);
        }
    }
}
