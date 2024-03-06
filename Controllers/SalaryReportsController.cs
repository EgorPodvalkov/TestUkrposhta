using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestUkrposhta.BusinessService;
using TestUkrposhta.DTOs;
using TestUkrposhta.Models;
using TestUkrposhta.Tools;

namespace TestUkrposhta.Controllers
{
    public class SalaryReportsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeBusinessService _employeeBS;
        private readonly IPositionBusinessService _positionBS;
        private readonly IDepartamentBusinessService _departamentBS;

        public SalaryReportsController(IMapper mapper, IEmployeeBusinessService employeeBS, IPositionBusinessService positionBS, IDepartamentBusinessService departamentBS)
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

        [HttpGet("GetSalaryReportsTableView")]
        public async Task<IActionResult> SalaryReportsTable()
        {
            try
            {
                // Getting employees
                var employeeDTOs = await _employeeBS.GetSalaryReportsAsync();
                var employeeModels = _mapper.Map<IEnumerable<SalaryReportsReadModel>>(employeeDTOs);

                var model = new SalaryReportsTableModel
                {
                    Employees = employeeModels,
                };

                // Render Table
                return View(model);
            }
            catch (Exception ex)
            {
                var model = new SalaryReportsTableModel
                {
                    Error = $"Error in GetSalaryReportsTableView get method: {ex.Message}",
                };

                // Render Table
                return View(model);
            }
        }

        [HttpPost("GetSalaryReportsTableView")]
        public async Task<IActionResult> SalaryReportsTableWithFilter()
        {
            try
            {
                // Getting filter
                var filterModel = await Request.ReadFromJsonAsync<SalaryReportsFilterModel>();
                var filterDTO = _mapper.Map<SalaryReportsFilter>(filterModel);

                // Getting employees
                var employeeDTOs = await _employeeBS.GetSalaryReportsAsync(filterDTO);
                var employeeModels = _mapper.Map<IEnumerable<SalaryReportsReadModel>>(employeeDTOs);

                var model = new SalaryReportsTableModel
                {
                    Employees = employeeModels,
                };

                // Render Table
                return View("SalaryReportsTable", model);
            }
            catch (Exception ex)
            {
                var model = new SalaryReportsTableModel
                {
                    Error = $"Error in GetSalaryReportsTableView post method: {ex.Message}",
                };

                // Render Table
                return View("SalaryReportsTable", model);
            }
        }


        [HttpPost("GetSalaryReportsTxtFile")]
        public async Task<IActionResult> GetSalaryReportsTxtFile()
        {
            try
            {
                // Getting filter
                var filterModel = await Request.ReadFromJsonAsync<SalaryReportsFilterModel>();
                var filterDTO = _mapper.Map<SalaryReportsFilter>(filterModel);

                // Getting employees
                var employeeDTOs = await _employeeBS.GetSalaryReportsAsync(filterDTO);
                var employeeModels = _mapper.Map<IEnumerable<SalaryReportsReadModel>>(employeeDTOs);

                var table = TxtGenerator.GetSalaryReportsTable(employeeModels, filterModel);

                // Sending file
                return File(table,
                 "text/plain",
                 "SalaryReport.txt");
            }
            catch (Exception ex)
            {
                // Render Table
                return Ok(new { Error = $"Error in GetSalaryReportsTxtFile: {ex.Message}" });
            }
        }
    }
}
