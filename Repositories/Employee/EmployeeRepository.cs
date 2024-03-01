using Dapper;
using TestUkrposhta.DTOs;

namespace TestUkrposhta.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(string connectionString) : base("Employees", connectionString) { }

        public async Task UpdateAsync(Employee employee)
        {
            // не подобається - треба подумати, як це автоматизувати
            var sql = $"UPDATE [{_tableName}] SET [FullName] = @FullName, [CompanyID] = @CompanyID, [DepartmentID] = @DepartmentID, [PositionID] = @PositionID, " +
                $"[Address] = @Address, [PhoneNumber] = @PhoneNumber, [BirthDate] = @BirthDate, [HireDate] = @HireDate, [Salary] = @Salary WHERE Id = @Id";

            using var db = _dbConnection;
            var affectedRows = await db.ExecuteAsync(sql, employee);
        }
    }
}
