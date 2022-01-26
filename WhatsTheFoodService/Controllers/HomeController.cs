using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WhatsTheFoodService.Context;
using WhatsTheFoodService.Models;

namespace WhatsTheFoodService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicationDbContext _applicationDbContext;

        public HomeController(ILogger<HomeController> logger, IApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        [Route("calories")]
        public string[] Calories()
        {            
            return Enumerable.Range(1,20).Select(x=>(x*100).ToString()).ToArray();
        }

       
    }
}

