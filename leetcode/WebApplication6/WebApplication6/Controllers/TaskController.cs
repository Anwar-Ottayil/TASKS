using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.Interface;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ItaskService _ItaskService;
        public TaskController(ItaskService itaskService)
        {
            _ItaskService = itaskService;
              
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetTask()
        {
            var res = await _ItaskService.GetTasks();
            return Ok(res);
        }
    }
}
