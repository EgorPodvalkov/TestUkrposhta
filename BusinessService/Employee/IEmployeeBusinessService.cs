using TestUkrposhta.DTOs;

namespace TestUkrposhta.BusinessService
{
    public interface IEmployeeBusinessService
    {
        /// <summary> Returns list of employees </summary>
        Task<IEnumerable<Employee>> GetAllAsync();
    }
}
