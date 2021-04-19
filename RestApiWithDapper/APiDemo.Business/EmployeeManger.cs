
using APIDemo.DataAccess.Interfaces;
using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace APIDemo.Business
{
    public class EmployeeManger
    {
        private readonly IDapper Idapper; //instantiate readonly object of IDapper interface
        private string ConnectionString = "DefaultConnection"; //set the name of the connection string mentioned in the appsettings
        public EmployeeManger(IDapper idapper)
        {
            Idapper = idapper; //set the Idapper oobject
        }
        public async Task<string> AddNewEmployee(Employee employee)
        {
            var dbparams = new DynamicParameters(); //cretae object of dynamic parameters add all required parameters 
            dbparams.Add("@FirstName", employee.FirstName, DbType.String);
            dbparams.Add("@LastName", employee.LastName, DbType.String);
            dbparams.Add("@Department", employee.Department, DbType.String);
            dbparams.Add("@JobTitle", employee.JobTitle, DbType.String);
            dbparams.Add("@PhoneExtension", employee.PhoneExtension, DbType.String);
            dbparams.Add("@Salary", employee.Salary, DbType.String);
            dbparams.Add("@Bonus", employee.Bonus, DbType.String);
            var result = await Task.FromResult(IDapper.InsertOrUpdate<string>("SPInsertEmployee", dbparams, ConnectionString)); //insert the data using the Insert method which is declared in Idapper interface and defined in EmployeeAction class
            return result;
        }
    }
}
