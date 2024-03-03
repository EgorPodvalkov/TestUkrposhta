using TestUkrposhta.Models;

namespace TestUkrposhta.BusinessService
{
    public interface IPositionBusinessService
    {
        Task<IEnumerable<PositionReadModel>> GetPositionsAsync();
    }
}
