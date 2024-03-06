using TestUkrposhta.DTOs;
using TestUkrposhta.Repositories;

namespace TestUkrposhta.BusinessService
{
    public class DepartamentBusinessService : IDepartamentBusinessService
    {
        private readonly IDepartamentRepository _repository;

        public DepartamentBusinessService(IDepartamentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Departament>> GetDepartamentsAsync()
        {
            var dtos = await _repository.GetAllAsync();
            return dtos;
        }
    }
}
