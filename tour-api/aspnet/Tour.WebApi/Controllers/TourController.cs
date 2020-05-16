using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace Tour.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class TourController : ControllerBase
    {

         static readonly List<Hero> _listHeroes = new List<Hero>(){
                new Hero(){
                    id = 1,
                    name = "Skyrock"
                },
                new Hero(){
                    id = 2,
                    name = "Iron Man"
                },
                new Hero(){
                    id = 3,
                    name = "Ipman"
                },
                 new Hero(){
                    id = 4,
                    name = "Hulk"
                },
                new Hero(){
                    id = 5,
                    name = "Captain America"
                },
                new Hero(){
                    id = 6,
                    name = "Xmen"
                },
                 new Hero(){
                    id = 7,
                    name = "Captain X"
                },
                new Hero(){
                    id = 8,
                    name = "Superman"
                }
            };
           

        [HttpGet]
        public IActionResult get()
        {
            return Ok(_listHeroes);
        }

        [HttpGet("{id}")]
        public IActionResult get(int id)
        {    
           return Ok(_listHeroes.Find(hero => hero.id == id));
        }


        [HttpPost]
        public IActionResult post(Hero hero)
        {
            Hero h = hero;
            return Ok(h);
        }
        
    }
}
