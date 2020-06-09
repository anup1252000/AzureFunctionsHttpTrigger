using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HttpTriggerVerify
{
    public class EmployeeContext : DbContext
    {
    

        public EmployeeContext(DbContextOptions<EmployeeContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Employee> Employees { get; set; }

       
    }
}
