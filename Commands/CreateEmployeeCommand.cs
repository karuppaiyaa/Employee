using Employee.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Commands
{
    public record CreateEmployeeCommand(Employees employee): IRequest<Employees>;
}
