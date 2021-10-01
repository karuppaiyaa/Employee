using Employee.Interfaces;
using Employee.Models;
using Employee.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Employee.Handlers
{
    public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, List<Employees>>
    {
        /*private readonly IEmployeeService employeeService;
        public GetAllEmployeesHandler(IEmployeeService employeeService)
        { 
            this.employeeService = employeeService;
        }*/
        private readonly IEmployeeRepository employeeRepository;
        public GetAllEmployeesHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<List<Employees>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await employeeRepository.GetAllAsync();
        }
    }
}
