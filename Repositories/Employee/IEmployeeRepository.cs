using TestUkrposhta.DTOs;

namespace TestUkrposhta.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        /// <summary> Updates item in db </summary>
        Task UpdateAsync(Employee item);

        /// <summary> Get list of employers by filter from db </summary>
        Task<IEnumerable<Employee>> GetListByFilterAsync(EmployeeFilter filter);
    }
}
