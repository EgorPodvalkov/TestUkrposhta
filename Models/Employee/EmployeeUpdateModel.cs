namespace TestUkrposhta.Models
{
    public class EmployeeUpdateModel
    {
        public int ID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public decimal Salary { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }

        public int CompanyID { get; set; }
        public int DepartamentID { get; set; }
        public int PositionID { get; set; }
    }
}
