using Employee.Interfaces;
using Employee.Models;
using Employee.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediatR.Extensions.Microsoft.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Employee.Queries;
using Employee.Commands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employee.Controllers
{

    [Route("Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Employees>> GetAllEmployees()
        {
            return await mediator.Send(new GetAllEmployeesQuery());
        }

        [HttpGet("{id}")]
        public async Task<Employees> GetEmployeeById(int id)
        {
            return await mediator.Send(new GetEmployeeByIdQuery(id));
        }

        [HttpPost]
        public async Task<Employees> CreateEmployee([FromBody] Employees employee)
        {
            return await mediator.Send(new CreateEmployeeCommand(employee));
        }

        [HttpPut("{id}")]
        public async Task<Employees> UpdateEmployeeById(int id, [FromBody] Employees employee)
        {
            return await mediator.Send(new UpdateEmployeeByIdCommand(id, employee));
        }

        [HttpDelete("{id}")]
        public async Task<int> DeleteEmployeeById(int id)
        {
            return await mediator.Send(new DeleteEmployeeByIdCommand(id));
        }
    }
}
