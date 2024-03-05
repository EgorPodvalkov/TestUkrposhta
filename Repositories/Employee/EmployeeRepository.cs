using Dapper;
using TestUkrposhta.DTOs;

namespace TestUkrposhta.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private const string baseSelect =
                @$"SELECT [Employees].*, [Companies].[Name] as CompanyName, [Positions].[Name] as PositionName, [Departaments].[Name] as DepartamentName 
                    FROM [Employees]
	                INNER JOIN [Positions] ON [Employees].[PositionID] = [Positions].[ID]	
	                INNER JOIN [Companies] ON [Employees].[CompanyID] = [Companies].[ID]
	                INNER JOIN [Departaments] ON [Employees].[DepartamentID] = [Departaments].[ID] ";

        public EmployeeRepository(string connectionString) : base("Employees", connectionString) { }

        public async Task UpdateAsync(Employee employee)
        {
            // не подобається - треба подумати, як це автоматизувати
            var sql = $"UPDATE [{_tableName}] SET [FullName] = @FullName, [DepartamentID] = @DepartamentID, [PositionID] = @PositionID, " +
                $"[Address] = @Address, [PhoneNumber] = @PhoneNumber, [BirthDate] = @BirthDate, [HireDate] = @HireDate, [Salary] = @Salary WHERE Id = @Id";

            using var db = _dbConnection;
            var affectedRows = await db.ExecuteAsync(sql, employee);
        }

        public override async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var sql = baseSelect;

            using var db = _dbConnection;
            return await db.QueryAsync<Employee>(sql);
        }

        public async Task<IEnumerable<Employee>> GetListByFilterAsync(EmployeeFilter filter)
        {
            var filterCondition = GetFilterCondition(filter);

            var whereSegment = !string.IsNullOrEmpty(filterCondition) ? $"WHERE {filterCondition}" : string.Empty;

            var sql = baseSelect + whereSegment;

            using var db = _dbConnection;
            return await db.QueryAsync<Employee>(sql);
        }

        private string GetFilterCondition(EmployeeFilter filter)
        {
            var filterConditions = new List<string>();
            if (filter is not null)
            {
                if (!string.IsNullOrEmpty(filter.FullName))
                    filterConditions.Add(@$"LOWER([FullName]) LIKE '%{filter.FullName}%' ");

                if (filter.MinSalary is not null)
                    filterConditions.Add(@$"[Salary] >= {filter.MinSalary} ");

                if (filter.MaxSalary is not null)
                    filterConditions.Add(@$"[Salary] <= {filter.MaxSalary} ");

                if (filter.PositionID is not null && filter.PositionID != -1)
                    filterConditions.Add(@$"[PositionID] = {filter.PositionID} ");

                if (filter.DepartamentID is not null && filter.DepartamentID != -1)
                    filterConditions.Add(@$"[DepartamentID] = {filter.DepartamentID} ");
            }

            var filterCondition = string.Join("AND ", filterConditions);

            return filterCondition;
        }

        public async override Task<Employee?> GetItemAsync(int id)
        {
            var sql = baseSelect + "WHERE [Employees].[ID] = @id";

            using var db = _dbConnection;
            return await db.QuerySingleOrDefaultAsync<Employee>(sql, new { id });
        }
    }
}
