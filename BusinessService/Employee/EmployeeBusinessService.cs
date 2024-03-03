using AutoMapper;
using TestUkrposhta.Models;
using TestUkrposhta.Repositories;

namespace TestUkrposhta.BusinessService
{
    public class EmployeeBusinessService : IEmployeeBusinessService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeBusinessService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeReadModel>> GetAllAsync()
        {
            var dtos = await _repository.GetAllAsync();
            var models = _mapper.Map<IEnumerable<EmployeeReadModel>>(dtos);

            return models;
        }
    }
}
