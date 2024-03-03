using TestUkrposhta.DTOs;

namespace TestUkrposhta.BusinessService
{
    public interface ICompanyBusinessService
    {
        Task<Company> GetCompanyAsync(int? companyID = null);
    }
}
