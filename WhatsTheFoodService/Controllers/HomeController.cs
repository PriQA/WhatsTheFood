using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WhatsTheFoodService.Models;

namespace WhatsTheFoodService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("calories")]
        public string[] Calories()
        {            
            return Enumerable.Range(1,40).Select(x=>(x*100).ToString()).ToArray();
        }

       
    }
}

