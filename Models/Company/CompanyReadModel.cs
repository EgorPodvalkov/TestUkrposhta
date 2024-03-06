namespace TestUkrposhta.Models
{
    public class CompanyReadModel
    {
        public int ID { get; set; }

        /// <summary> Name of company </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary> Company description </summary>
        public string Info { get; set; } = string.Empty;
    }
}
