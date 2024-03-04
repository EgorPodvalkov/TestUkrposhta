using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestUkrposhta.BusinessService;
using TestUkrposhta.DTOs;
using TestUkrposhta.Models;

namespace TestUkrposhta.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeBusinessService _employeeBS;
        private readonly IPositionBusinessService _positionBS;
        private readonly IDepartamentBusinessService _departamentBS;

        public EmployeeController(IMapper mapper, IEmployeeBusinessService employeeBS, IPositionBusinessService positionBS, IDepartamentBusinessService departamentBS)
        {
            _mapper = mapper;
            _employeeBS = employeeBS;
            _positionBS = positionBS;
            _departamentBS = departamentBS;
        }

        public async Task<IActionResult> Index()
        {
            // Getting positions and departaments for dropdown lists for page
            var positionDTOs = await _positionBS.GetPositionsAsync();
            var departamentDTOs = await _departamentBS.GetDepartamentsAsync();

            var positionModels = _mapper.Map<IList<PositionReadModel>>(positionDTOs);
            var departamentModels = _mapper.Map<IList<DepartamentReadModel>>(departamentDTOs);

            var model = new EmployeeFilterDropDownListsModel(positionModels, departamentModels);

            // Render Page
            return View(model);
        }

        [HttpGet("GetEmployeesTableView")]
        public async Task<IActionResult> EmployeesTable()
        {
            try
            {
                // Getting employees
                var employeeDTOs = await _employeeBS.GetAllAsync();
                var employeeModels = _mapper.Map<IEnumerable<EmployeeReadModel>>(employeeDTOs);

                var model = new EmployeeTableModel
                {
                    Employees = employeeModels,
                };

                // Render Table
                return View(model);
            }
            catch (Exception ex)
            {
                var model = new EmployeeTableModel
                {
                    Error = $"Error 'GetEmployeesTableView' get method: {ex.Message}",
                };

                // Render Table
                return View(model);
            }
        }

        [HttpPost("GetEmployeesTableView")]
        public async Task<IActionResult> EmployeesTableWithFilter()
        {
            try
            {
                // Getting filter
                var filterModel = await Request.ReadFromJsonAsync<EmployeeFilterModel>();
                var filterDTO = _mapper.Map<EmployeeFilter>(filterModel);

                // Getting employees
                var employeeDTOs = await _employeeBS.GetListByFilterAsync(filterDTO);
                var employeeModels = _mapper.Map<IEnumerable<EmployeeReadModel>>(employeeDTOs);

                var model = new EmployeeTableModel
                {
                    Employees = employeeModels,
                };

                // Render Table
                return View("EmployeesTable", model);
            }
            catch (Exception ex)
            {
                var model = new EmployeeTableModel
                {
                    Error = $"Error \"GetEmployeesTableView\" post method: {ex.Message}",
                };

                // Render Table
                return View("EmployeesTable", model);
            }
        }
    }
}