using TestUkrposhta.DTOs;

namespace TestUkrposhta.BusinessService
{
    public interface IPositionBusinessService
    {
        Task<IEnumerable<Position>> GetPositionsAsync();
    }
}
