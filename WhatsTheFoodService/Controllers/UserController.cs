using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsTheFoodService.Context;
using WhatsTheFoodService.Models;

namespace WhatsTheFoodService.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicationDbContext _applicationDbContext;

        public UserController(ILogger<HomeController> logger, IApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
           }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return await _applicationDbContext.Users.ToListAsync();
        }


        [HttpGet("{UserId:int}")]
        public async Task<ActionResult<List<User>>> Get(int userId)
        {
            if (userId == 0)
            {
                return await _applicationDbContext.Users.ToListAsync();
            }
            return await _applicationDbContext.Users.Where(x => x.UserId <= userId).ToListAsync();
        }


        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterUser([FromBody] User userDetails)
        {
            if (userDetails == null || !ModelState.IsValid)
                return BadRequest();

           
            return StatusCode(200);
        }

    }
}
