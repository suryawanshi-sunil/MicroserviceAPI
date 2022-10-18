using Company.API.Entities;
using Company.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Company.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _repository;
        private readonly ILogger _logger;

       
        public CompanyController(ICompanyRepository repository, ILogger<CompanyController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
           _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CompanyModel>),(int) HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CompanyModel>>> GetCompanies()
        {
            var companies = await _repository.GetCompanies();
            return Ok(companies);
        }


        [HttpGet("{companycode}", Name = "GetCompany")]
       // [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(CompanyModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CompanyModel>> GetCompanyByCode(string companycode, bool isSearch = false)
        {
            if (isSearch)
            {
                var companies = await _repository.GetSearchedCompanyList(companycode);
                if (companies == null)
                {
                    _logger.LogError($"Company with Id: {companycode}, not found");
                    return NotFound();
                }
                return Ok(companies);
            }
            else
            {
                var company = await _repository.GetCompany(companycode);
                if (company == null)
                {
                    _logger.LogError($"Company with Id: {companycode}, not found");
                    return NotFound();
                }
                return Ok(company);
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<CompanyModel>> CreateCompany([FromBody] CompanyModel companyModel)
        {
            var company = await _repository.GetCompany(companyModel.Company_Code);
            if (company != null)
            {
                _logger.LogError($"Company with Id: {companyModel.Company_Code}, is found");
                return Ok(new { message = "Company code already exist" });
            }
            await _repository.CreateCompany(companyModel);
            return CreatedAtRoute("GetCompany", new { companycode = companyModel.Company_Code }, companyModel);
        }

        [HttpDelete("{companycode}", Name = "DeleteCompany")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCompany(string companycode)
        {
            return Ok(await _repository.DeleteCompany(companycode));
        }
    }
}
