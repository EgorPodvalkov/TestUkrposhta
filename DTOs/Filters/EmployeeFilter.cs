namespace TestUkrposhta.DTOs
{
    public class EmployeeFilter
    {
        public string? FullName { get; set; }
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }
        public int? PositionID { get; set; }
        public int? DepartamentID { get; set; }
    }
}
