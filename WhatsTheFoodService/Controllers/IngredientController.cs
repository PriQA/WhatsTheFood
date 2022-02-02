using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhatsTheFoodService.Context;
using WhatsTheFoodService.Models;

namespace WhatsTheFoodService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientController : Controller
    {
        private readonly ILogger<IngredientController> _logger;
        private readonly IApplicationDbContext _applicationDbContext;

        public IngredientController(ILogger<IngredientController> logger, IApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 403)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<ActionResult<List<Ingredient>>> Get()
        {
            return await _applicationDbContext.Ingredients.ToListAsync();
        }
    }
}
