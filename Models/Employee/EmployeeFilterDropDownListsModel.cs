namespace TestUkrposhta.Models
{
    /// <summary> Model for filling dropdown lists for employee filter </summary>
    public class EmployeeFilterDropDownListsModel
    {
        public IEnumerable<PositionReadModel> Positions { get; private set; }
        public IEnumerable<DepartamentReadModel> Departaments { get; private set; }

        public EmployeeFilterDropDownListsModel(IList<PositionReadModel> positions, IList<DepartamentReadModel> departaments)
        {
            positions.Insert(0, new PositionReadModel { ID = -1, Name = "All positions" });
            departaments.Insert(0, new DepartamentReadModel { ID = -1, Name = "All departaments" });

            Positions = positions;
            Departaments = departaments;
        }
    }
}
