using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(HttpTriggerVerify.Startup))]
namespace HttpTriggerVerify
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string SqlConnection = Environment.GetEnvironmentVariable("SqlConnectionString");
            builder.Services.AddDbContext<EmployeeContext>(x => x.UseSqlServer(SqlConnection));
        }
    }

    public class EmployeeContextFactory : IDesignTimeDbContextFactory<EmployeeContext>
    {
        public EmployeeContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmployeeContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnectionString"));

            return new EmployeeContext(optionsBuilder.Options);
        }
    }
}
