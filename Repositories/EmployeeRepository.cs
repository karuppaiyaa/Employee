using Employee.Common;
using Employee.Interfaces;
using Employee.Models;
using Dapper;
using MediatR;
using MediatR.Extensions.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;


namespace Employee.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<Employees> Create(Employees employee)
        {
            using (IDbConnection connectionPostgreSQL = new NpgsqlConnection(Global.ConnectionStringPostgreSQL))
            {
                var param = new DynamicParameters();
                param.Add("@name", employee.name);
                param.Add("@age", employee.age);
                await Task.FromResult(connectionPostgreSQL.Execute($"insert into public.Employee values(default, @name, @age)", param, commandType: CommandType.Text));
                return employee;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (IDbConnection connectionPostgreSQL = new NpgsqlConnection(Global.ConnectionStringPostgreSQL))
            {
                var param = new DynamicParameters();
                param.Add("@id", id);
                int result = await Task.FromResult(connectionPostgreSQL.Execute($"DELETE FROM public.Employee WHERE id = @id",param, commandType: CommandType.Text));
                return result;
            }
        }

        public Task<List<Employees>> GetAllAsync()
        {
            using (IDbConnection connectionPostgreSQL = new NpgsqlConnection(Global.ConnectionStringPostgreSQL))
            {
                var querySQL = @"SELECT * FROM public.Employee;";
                IList<Employees> employeeList =  connectionPostgreSQL.Query<Employees>(querySQL).ToList();
                return Task.FromResult(employeeList.ToList());
            }
        }

        public Task<Employees> GetByIdAsync(int id)
        {
            using (IDbConnection connectionPostgreSQL = new NpgsqlConnection(Global.ConnectionStringPostgreSQL))
            {
                var param = new DynamicParameters();
                param.Add("@id", id);
                var result = connectionPostgreSQL.Query<Employees>(@"Select * from public.Employee Where id = @id", param, commandType: CommandType.Text).FirstOrDefault();
                return Task.FromResult(result);
            }
        }

        public async Task<Employees> Update(int id, Employees employee)
        {
            if (employee != null)
            {
                if (id == employee.id)
                {
                    using (IDbConnection connectionPostgreSQL = new NpgsqlConnection(Global.ConnectionStringPostgreSQL))
                    {
                        Task<Employees> employeeExists = this.GetByIdAsync(id);
                        if (employeeExists.Result != null)
                        {
                            var param = new DynamicParameters();
                            param.Add("@name", employee.name);
                            param.Add("@age", employee.age);
                            param.Add("@id", employee.id);
                            await Task.FromResult(connectionPostgreSQL.Execute($"Update public.Employee set name = @name,age = @age Where id = @id", param, commandType: CommandType.Text));
                            return employee;
                        }
                    }
                }
            }
            return null;
        }
    }
}
