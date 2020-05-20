using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Tour.DataContext;
using Tour.Domains.Models;

namespace Tour.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class TourController : ControllerBase
    {
        private readonly HeroRepository _heroRepo;
        //  static readonly List<Hero> _listHeroes = new List<Hero>(){
        //         new Hero(){
        //             id = "1",
        //             name = "Skyrock"
        //         },
        //         new Hero(){
        //             id = "2",
        //             name = "Iron Man"
        //         },
        //         new Hero(){
        //             id = "3",
        //             name = "Ipman"
        //         },
        //          new Hero(){
        //             id = "4",
        //             name = "Hulk"
        //         },
        //         new Hero(){
        //             id = "5",
        //             name = "Captain America"
        //         },
        //         new Hero(){
        //             id = "6",
        //             name = "Xmen"
        //         },
        //          new Hero(){
        //             id = "7",
        //             name = "Captain X"
        //         },
        //         new Hero(){
        //             id = "8",
        //             name = "Superman"
        //         }
        //     };
           

        public TourController(HeroRepository repo)
        {
            _heroRepo = repo;
        }

        [HttpGet]
        public IActionResult get()
        {
            return Ok(_heroRepo.Get());
        }

        [HttpGet("{id}")]
        public IActionResult get(string id)
        {    
           return Ok(_heroRepo.Get(id));
        }


        [HttpPost]
        public IActionResult post(Hero hero)
        {
            Hero h = hero;
            return Ok(_heroRepo.Create(hero));
        }

        [HttpPut("{Id}")]
        public IActionResult put(string id, Hero heroIn)
        {
            _heroRepo.Update(id, heroIn);
            return Ok("updated");
        }

        [HttpDelete]
        public IActionResult delete(string id)
        {
            var hero = _heroRepo.Get(id);
            if(hero != null)
            {
                _heroRepo.Remove(hero);
                return Ok();
            } else {
                return BadRequest("The object you're trying to delete doesn't exist");
            }
            
        }
        
    }
}
