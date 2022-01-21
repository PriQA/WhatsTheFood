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
    public class FoodController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicationDbContext _applicationDbContext;

        public FoodController(ILogger<HomeController> logger, IApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Food>>> Get()
        {
            return await _applicationDbContext.Foods.ToListAsync();
        }

        [HttpGet("{calorie:int}")]
        public async Task<ActionResult<List<Food>>> Get(int calorie)
        {
            return await _applicationDbContext.Foods.Where(x => x.Calorie <= calorie).ToListAsync();
        }
    }
}

