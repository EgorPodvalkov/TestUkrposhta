namespace TestUkrposhta.Models
{
    /// <summary> Model for filling dropdown lists for employee filter </summary>
    public class EmployeeFilterDropDownListsModel
    {
        public IEnumerable<PositionReadModel> Positions { get; set; }
        public IEnumerable<DepartamentReadModel> Departaments { get; set; }

        public EmployeeFilterDropDownListsModel(IList<PositionReadModel> positions, IList<DepartamentReadModel> departaments)
        {
            Positions = positions;
            Departaments = departaments;
        }
    }
}
