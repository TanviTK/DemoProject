
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApiWithDapper.Models;
using APIDemo.SharedEntities.Models;

namespace RestApiWithDapper.Models
{
    public class EmployeeInfoContext : DbContext
    {
        public EmployeeInfoContext(DbContextOptions<EmployeeInfoContext> options) : base(options) { }
        public DbSet<Employee> Employee { get; set; } 
    }
}
