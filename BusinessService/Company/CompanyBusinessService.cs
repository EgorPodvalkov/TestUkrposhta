using TestUkrposhta.DTOs;
using TestUkrposhta.Repositories;

namespace TestUkrposhta.BusinessService
{
    public class CompanyBusinessService : ICompanyBusinessService
    {
        private readonly ICompanyRepository _repository;

        public CompanyBusinessService(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Company> GetCompanyAsync(int? companyID = null)
        {
            // if company is null getting default company
            const int defaultCompanyID = 1;

            var dto = await _repository.GetItemAsync(companyID ?? defaultCompanyID);

            if (dto is null)
                throw new Exception($"No company in db with ID {companyID}");

            return dto;
        }
    }
}
