using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.Interface;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IuserService _service;
        public UserController(IuserService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Login(string email,string password)
        {
            var res = await _service.Login(email, password);
            return Ok(res);
        }
    }
}
