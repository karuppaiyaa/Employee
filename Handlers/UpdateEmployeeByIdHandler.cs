using Employee.Interfaces;
using Employee.Models;
using Employee.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Employee.Handlers
{
    public class UpdateEmployeeByIdHandler : IRequestHandler<UpdateEmployeeByIdCommand, Employees>
    {
        /*private readonly IEmployeeService employeeService;
        public UpdateEmployeeByIdHandler(IEmployeeService employeeService)
        { 
            this.employeeService = employeeService;
        }*/
        private readonly IEmployeeRepository employeeRepository;
        public UpdateEmployeeByIdHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<Employees> Handle(UpdateEmployeeByIdCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.Update(request.id, request.employee);
        }
    }
}
