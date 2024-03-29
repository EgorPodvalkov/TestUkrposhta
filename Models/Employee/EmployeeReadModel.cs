﻿namespace TestUkrposhta.Models
{
    public class EmployeeReadModel
    {
        public int ID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }

        public string CompanyName { get; set; } = string.Empty;
        public string DepartamentName { get; set; } = string.Empty;
        public string PositionName { get; set; } = string.Empty;
    }
}
