using AutoMapper;
using TestUkrposhta.Models;
using TestUkrposhta.Repositories;

namespace TestUkrposhta.BusinessService
{
    public class CompanyBusinessService : ICompanyBusinessService
    {
        private readonly ICompanyRepository _repository;
        private readonly IMapper _mapper;

        public CompanyBusinessService(ICompanyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CompanyReadModel> GetCompanyAsync()
        {
            // Only 1 company in db
            const int companyID = 1;
            var dto = await _repository.GetItemAsync(companyID);
            var model = _mapper.Map<CompanyReadModel>(dto);

            return model;
        }
    }
}
