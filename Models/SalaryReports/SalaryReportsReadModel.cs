namespace TestUkrposhta.Models
{
    public class SalaryReportsReadModel
    {
        public int ID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public decimal Salary { get; set; }

        public string? CompanyName { get; set; }
        public string? DepartamentName { get; set; }
        public string? PositionName { get; set; }
    }
}
