using desafio.Interfaces.Services;
using desafio.Models;
using Microsoft.AspNetCore.Mvc;

namespace desafio.Controllers
{
    [ApiController]
    [Route("api/grupo")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupSerivce groupService;
        public GroupController(IGroupSerivce groupService)
        {
            this.groupService = groupService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var statusData = groupService.FindById(id);

            return StatusCode((int)statusData.HttpStatusCode, statusData.Data ?? statusData.Message);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Group group)
        {
            var statusData = groupService.Save(group);
            return StatusCode((int)statusData.HttpStatusCode, statusData.Data ?? statusData.Message);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string date)
        {
            var statusData = groupService.FindAllCompany(date);

            return StatusCode((int)statusData.HttpStatusCode, statusData.Data ?? statusData.Message);

        }
    }
}