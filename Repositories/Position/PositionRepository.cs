using TestUkrposhta.DTOs;

namespace TestUkrposhta.Repositories
{
    public class PositionRepository : BaseRepository<Position>, IPositionRepository
    {
        public PositionRepository(string connectionString) : base("Positions", connectionString) { }
    }
}
