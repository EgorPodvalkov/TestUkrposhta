namespace TestUkrposhta.DTOs
{
    public class Employee : BaseDTO
    {
        public string FullName { get; set; } = string.Empty;
        public int CompanyID { get; set; }
        public int DepartamentID { get; set; }
        public int PositionID { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public decimal Salary { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }

        public Company? Company { get; set; }
        public Departament? Departament { get; set; }
        public Position? Position { get; set; }
    }
}
