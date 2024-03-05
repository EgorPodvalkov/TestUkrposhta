using TestUkrposhta.DTOs;

namespace TestUkrposhta.BusinessService
{
    public interface IEmployeeBusinessService
    {
        /// <summary> Returns list of employees </summary>
        Task<IEnumerable<Employee>> GetAllAsync();

        /// <summary> Gets list of employers by filter from db </summary>
        Task<IEnumerable<Employee>> GetListByFilterAsync(EmployeeFilter filter);

        /// <summary> Gets employee by ID from db </summary>
        Task<Employee?> GetEmployeeAsync(int id);

        /// <summary> Updates employee in db </summary>
        Task UpdateEmployeeAsync(Employee employee);
    }
}
