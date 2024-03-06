namespace TestUkrposhta.Models
{
    public class SalaryReportsTableModel
    {
        public IEnumerable<SalaryReportsReadModel> Employees { get; set; } = new List<SalaryReportsReadModel>();
        public string Error { get; set; } = string.Empty;
    }
}
