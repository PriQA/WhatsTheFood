using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhatsTheFoodService.Models;

namespace WhatsTheFoodService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Food>>> Get()
        {
            return new List<Food>
            {
                new Food
                {
                FoodId = 1,
                Name = "Burger",
                Calorie = 200,
                ImageLocation ="./image/burger"
                },
                new Food
                {
                FoodId = 2,
                Name = "Salad",
                Calorie = 100,
                ImageLocation ="./image/Salad"
                },
                new Food
                {
                FoodId = 3,
                Name = "Ice cream",
                Calorie = 300,
                ImageLocation ="./image/iceCream"
                },
                new Food
                {
                FoodId = 4,
                Name = "Biriyani",
                Calorie = 1000,
                ImageLocation ="./image/Biriyani"
                }
                ,
                new Food
                {
                FoodId = 5,
                Name = "Subs",
                Calorie = 500,
                ImageLocation ="./image/Subs"
                }


            };
        }

        [HttpGet("{calorie:int}")]
        public async Task<ActionResult<List<Food>>> Get(int calorie)
        {
            return  new List<Food>
            {
                new Food
                {
                FoodId = 1,
                Name = "Burger",
                Calorie = 200,
                ImageLocation ="./image/burger"
                },
                new Food
                {
                FoodId = 2,
                Name = "Salad",
                Calorie = 100,
                ImageLocation ="./image/Salad"
                }

            };
        }   
    }
}

