using desafio.Interfaces.Services;
using desafio.Models;
using Microsoft.AspNetCore.Mvc;

namespace desafio.Controllers
{
    [ApiController]
    [Route("api/empresa")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;
        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(string id)
        {
            var statusData = companyService.FindById(id);

            return StatusCode((int)statusData.HttpStatusCode, statusData.Data ?? statusData.Message);

        }

        [HttpPost]
        public IActionResult Post([FromBody] List<Company> companies)
        {
            var statusData = companyService.Save(companies);
            return StatusCode((int)statusData.HttpStatusCode, statusData.Data ?? statusData.Message);
        }

        [HttpPut]
        [Route("custos/{id}")]
        public IActionResult Post(string id, [FromBody] Cost cost)
        {
            var statusData = companyService.SaveCost(id, cost);
            return StatusCode((int)statusData.HttpStatusCode, statusData.Data ?? statusData.Message);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            var statusData = companyService.Delete(id);

            return StatusCode((int)statusData.HttpStatusCode, statusData.Data ?? statusData.Message);

        }
    }
}