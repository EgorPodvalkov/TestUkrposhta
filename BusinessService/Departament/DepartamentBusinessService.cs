using AutoMapper;
using TestUkrposhta.Models;
using TestUkrposhta.Repositories;

namespace TestUkrposhta.BusinessService
{
    public class DepartamentBusinessService : IDepartamentBusinessService
    {
        private readonly IDepartamentRepository _repository;
        private readonly IMapper _mapper;

        public DepartamentBusinessService(IDepartamentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartamentReadModel>> GetDepartamentsAsync()
        {
            var dtos = await _repository.GetAllAsync();
            var models = _mapper.Map<IEnumerable<DepartamentReadModel>>(dtos);

            return models;
        }
    }
}
