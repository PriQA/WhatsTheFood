using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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


        [HttpPost("register")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(ProblemDetails),400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 403)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> Register([FromBody] User newUser)
        {
            if (newUser == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _applicationDbContext.Users.Add(newUser);
                _ = _applicationDbContext.SaveChanges();
                return StatusCode(200);
            }
            catch (Exception e)
            {

               var errorResponse = new ProblemDetails()
                {
                    Title = e.Message,
                    Detail = e.InnerException.Message,
                    Status = (int)HttpStatusCode.InternalServerError
                };

                return BadRequest(errorResponse);
            }            
        }

        [HttpPost("signin")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 403)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> Signin([FromBody] User user)
        {
            if (string.IsNullOrEmpty(user.UserName))
                return BadRequest();

            if (string.IsNullOrEmpty(user.Password))
                return BadRequest();

            var users = await _applicationDbContext.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).ToListAsync();

            if (users.Any())
            {
                return StatusCode(200);
            }
            return StatusCode(401);
        }

    }
}
