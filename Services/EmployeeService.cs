using Employee.Interfaces;
using Employee.Models;
using Employee.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<Employees> Create(Employees employee)
        {
            return await employeeRepository.Create(employee);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await employeeRepository.DeleteAsync(id);
        }

        public async Task<List<Employees>> GetAllAsync()
        {
            return await employeeRepository.GetAllAsync();
        }

        public async Task<Employees> GetByIdAsync(int id)
        {
            return await employeeRepository.GetByIdAsync(id);
        }

        public async Task<Employees> Update(int id, Employees employee)
        {
            return await employeeRepository.Update(id, employee);
        }
    }
}
