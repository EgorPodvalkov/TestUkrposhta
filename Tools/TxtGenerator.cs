using System.Text;
using TestUkrposhta.Models;

namespace TestUkrposhta.Tools
{
    public static class TxtGenerator
    {
        public static byte[] GetSalaryReportsTable(IEnumerable<SalaryReportsReadModel> employees, SalaryReportsFilterModel filter)
        {
            var builder = new StringBuilder();

            var allDepartaments = filter.DepartamentID == -1 || filter.DepartamentID is null;
            var allPositions = filter.PositionID == -1 || filter.PositionID is null;

            var departamentFilter = allDepartaments ? "ALL" : employees.FirstOrDefault()?.DepartamentName ?? filter.DepartamentID.ToString();
            var positionFilter = allPositions ? "ALL" : employees.FirstOrDefault()?.PositionName ?? filter.PositionID.ToString();

            builder.AppendLine($"Salary report with filter: Departament - {departamentFilter}, Position - {positionFilter}.");

            builder.AppendLine($"Summary: {employees.Count()} employees, sum salary = {employees.Sum(x => x.Salary)} uah, avg salary = {employees.Average(x => x.Salary)} uah.");

            builder.AppendLine();
            builder.AppendLine("ID \tFullName \tPosition \tCompany \tDepartament \tSalary");
            foreach (var employee in employees)
            {
                builder.AppendLine($"{employee.ID} \t{employee.FullName} \t{employee.PositionName} \t{employee.CompanyName} \t{employee.DepartamentName} \t{employee.Salary}");
            }

            return Encoding.UTF8.GetBytes(builder.ToString());
        }
    }
}
