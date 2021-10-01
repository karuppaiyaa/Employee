using Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<List<Employees>> GetAllAsync();
        public Task<Employees> GetByIdAsync(int id);
        public Task<Employees> Create(Employees employee);
        public Task<Employees> Update(int id, Employees employee);
        public Task<int> DeleteAsync(int id);
    }
}
