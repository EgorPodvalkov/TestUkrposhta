using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestUkrposhta.BusinessService;
using TestUkrposhta.Models;

namespace TestUkrposhta.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICompanyBusinessService _companyBS;

        public CompanyController(IMapper mapper, ICompanyBusinessService companyBS)
        {
            _mapper = mapper;
            _companyBS = companyBS;
        }

        public async Task<IActionResult> Index()
        {
            var companyDTO = await _companyBS.GetCompanyAsync();
            var companyModel = _mapper.Map<CompanyReadModel>(companyDTO);

            return View(companyModel);
        }

        [HttpGet("Company/{companyID}")]
        public async Task<IActionResult> GetCompanyInfo(int? companyID = null)
        {
            var companyDTO = await _companyBS.GetCompanyAsync(companyID);
            var companyModel = _mapper.Map<CompanyReadModel>(companyDTO);

            return View(companyModel);
        }
    }
}
