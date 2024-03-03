using TestUkrposhta.Models;

namespace TestUkrposhta.BusinessService
{
    public interface ICompanyBusinessService
    {
        Task<CompanyReadModel> GetCompanyAsync();
    }
}
