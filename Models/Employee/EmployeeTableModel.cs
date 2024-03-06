namespace TestUkrposhta.Models
{
    public class EmployeeTableModel
    {
        public IEnumerable<EmployeeReadModel> Employees { get; set; } = new List<EmployeeReadModel>();

        public string Error { get; set; } = string.Empty;
    }
}
