using TestUkrposhta.DTOs;

namespace TestUkrposhta.BusinessService
{
    public interface IDepartamentBusinessService
    {
        Task<IEnumerable<Departament>> GetDepartamentsAsync();
    }
}
