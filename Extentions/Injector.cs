using TestUkrposhta.BusinessService;
using TestUkrposhta.Mapping;
using TestUkrposhta.Repositories;

namespace TestUkrposhta.Extentions
{
    public static class Injector
    {
        public static void InjectRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionString"] ?? throw new Exception("Can`t find ConnectionString in appsettings.json");

            services.AddScoped<IEmployeeRepository>(provider => new EmployeeRepository(connectionString));
            services.AddScoped<ICompanyRepository>(provider => new CompanyRepository(connectionString));
            services.AddScoped<IPositionRepository>(provider => new PositionRepository(connectionString));
            services.AddScoped<IDepartamentRepository>(provider => new DepartamentRepository(connectionString));
        }

        public static void InjectBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeBusinessService, EmployeeBusinessService>();
            services.AddScoped<IDepartamentBusinessService, DepartamentBusinessService>();
            services.AddScoped<IPositionBusinessService, PositionBusinessService>();
            services.AddScoped<ICompanyBusinessService, CompanyBusinessService>();
        }

        public static void InjectAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
