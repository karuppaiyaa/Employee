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
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employees>
    {
        /*private readonly IEmployeeService employeeService;
        public GetEmployeeByIdHandler(IEmployeeService employeeService)
        { 
            this.employeeService = employeeService;
        }*/
        private readonly IEmployeeRepository employeeRepository;
        public GetEmployeeByIdHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<Employees> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await employeeRepository.GetByIdAsync(request.id);
        }
    }
}
