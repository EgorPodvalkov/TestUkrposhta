using AutoMapper;
using TestUkrposhta.Models;
using TestUkrposhta.Repositories;

namespace TestUkrposhta.BusinessService
{
    public class PositionBusinessService : IPositionBusinessService
    {
        private readonly IPositionRepository _repository;
        private readonly IMapper _mapper;

        public PositionBusinessService(IPositionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PositionReadModel>> GetPositionsAsync()
        {
            var dtos = await _repository.GetAllAsync();
            var models = _mapper.Map<IEnumerable<PositionReadModel>>(dtos);

            return models;
        }
    }
}
