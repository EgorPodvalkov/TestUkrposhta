using TestUkrposhta.DTOs;

namespace TestUkrposhta.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        /// <summary> Updates item in db </summary>
        Task UpdateAsync(Employee item);
    }
}
