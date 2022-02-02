using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WhatsTheFoodService.Context;
using WhatsTheFoodService.Models;
using WhatsTheFoodService.TokenService;

namespace WhatsTheFoodService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly JwtHandler _jwtHandler;

        public UserController(ILogger<HomeController> logger, IApplicationDbContext applicationDbContext, JwtHandler jwtHandler)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
            _jwtHandler = jwtHandler;
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
                await _applicationDbContext.SaveChanges();
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

        [HttpPost("authenticate")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(AuthenticationReponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 403)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> Authenticate([FromBody] LoginUser user)
        {
            if (user.UserName == null || !ModelState.IsValid)
                return BadRequest();

            if (user.Password == null || !ModelState.IsValid)
                return BadRequest();

            var userList = _applicationDbContext.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).ToList();

            if (userList.Count > 0)
            {
                var signingCredentials = _jwtHandler.GetSigningCredentials();
                var claims = _jwtHandler.GetClaims(userList[0]);
                var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new AuthenticationReponse
                {
                    IsAuthenticated = true,
                    FirstName = userList[0].FirstName,
                    LastName = userList[0].LastName,
                    Role = userList[0].Role,
                    Token = token
                });
            }
                                
            return StatusCode(401);
        }

    }
}
