using TestUkrposhta.DTOs;

namespace TestUkrposhta.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        /// <summary> Updates item in db </summary>
        Task UpdateAsync(Employee item);

        /// <summary> Get list of employers by filter from db </summary>
        Task<IEnumerable<Employee>> GetListByFilterAsync(EmployeeFilter filter);

        /// <summary> Get list of employers with fields for salary reports by filter from db </summary>
        Task<IEnumerable<Employee>> GetSalaryReportsAsync(SalaryReportsFilter filter);
    }
}
