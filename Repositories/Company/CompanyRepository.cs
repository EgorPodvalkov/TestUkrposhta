using TestUkrposhta.DTOs;

namespace TestUkrposhta.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(string connectionString) : base("Companies", connectionString) { }
    }
}
