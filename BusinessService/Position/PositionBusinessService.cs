using TestUkrposhta.DTOs;
using TestUkrposhta.Repositories;

namespace TestUkrposhta.BusinessService
{
    public class PositionBusinessService : IPositionBusinessService
    {
        private readonly IPositionRepository _repository;

        public PositionBusinessService(IPositionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Position>> GetPositionsAsync()
        {
            var dtos = await _repository.GetAllAsync();
            return dtos;
        }
    }
}
