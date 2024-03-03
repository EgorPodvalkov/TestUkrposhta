using TestUkrposhta.Models;

namespace TestUkrposhta.BusinessService
{
    public interface IEmployeeBusinessService
    {
        /// <summary> Returns list of employees </summary>
        Task<IEnumerable<EmployeeReadModel>> GetAllAsync();
    }
}
