using TestUkrposhta.DTOs;
using TestUkrposhta.Repositories;

namespace TestUkrposhta.BusinessService
{
    public class EmployeeBusinessService : IEmployeeBusinessService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeBusinessService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var dtos = await _repository.GetAllAsync();
            return dtos;
        }

        public async Task<IEnumerable<Employee>> GetListByFilterAsync(EmployeeFilter filter)
        {
            var dtos = await _repository.GetListByFilterAsync(filter);
            return dtos;
        }
    }
}
