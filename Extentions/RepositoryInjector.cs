using TestUkrposhta.Repositories;

namespace TestUkrposhta.Extentions
{
    public static class RepositoryInjector
    {
        public static void InjectRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionString"] ?? throw new Exception("Can`t find ConnectionString in appsettings.json");

            services.AddScoped<IEmployeeRepository>(provider => new EmployeeRepository(connectionString));
            services.AddScoped<ICompanyRepository>(provider => new CompanyRepository(connectionString));
            services.AddScoped<IPositionRepository>(provider => new PositionRepository(connectionString));
            services.AddScoped<IDepartamentRepository>(provider => new DepartamentRepository(connectionString));

            //services.AddAutoMapper(typeof());
        }
    }
}
