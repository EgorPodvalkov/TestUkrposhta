using TestUkrposhta.Models;

namespace TestUkrposhta.BusinessService
{
    public interface IDepartamentBusinessService
    {
        Task<IEnumerable<DepartamentReadModel>> GetDepartamentsAsync();
    }
}
