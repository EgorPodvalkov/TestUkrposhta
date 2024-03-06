using TestUkrposhta.DTOs;

namespace TestUkrposhta.Repositories
{
    public class DepartamentRepository : BaseRepository<Departament>, IDepartamentRepository
    {
        public DepartamentRepository(string connectionString) : base("Departaments", connectionString) { }
    }
}
