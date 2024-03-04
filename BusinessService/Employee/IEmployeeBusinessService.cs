using TestUkrposhta.DTOs;

namespace TestUkrposhta.BusinessService
{
    public interface IEmployeeBusinessService
    {
        /// <summary> Returns list of employees </summary>
        Task<IEnumerable<Employee>> GetAllAsync();

        /// <summary> Get list of employers by filter from db </summary>
        Task<IEnumerable<Employee>> GetListByFilterAsync(EmployeeFilter filter);
    }
}
