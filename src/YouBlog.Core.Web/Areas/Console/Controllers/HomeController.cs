using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace YouBlog.Core.Web.Areas.Console.Controllers
{
    [Area("Console")]
    public class HomeController : Controller
    {
        private static List<Hero> Heroes = new Hero[] {
            new Hero { Id = 11, Name = "Mr. Nice" },
            new Hero { Id = 12, Name = "Narco" },
            new Hero { Id = 13, Name = "Bombasto" },
            new Hero { Id = 14, Name = "Celeritas" },
            new Hero { Id = 15, Name = "Magneta" },
            new Hero { Id = 16, Name = "RubberMan" },
            new Hero { Id = 17, Name = "Dynama" },
            new Hero { Id = 18, Name = "Dr IQ" },
            new Hero { Id = 19, Name = "Magma" },
            new Hero { Id = 20, Name = "Tornado" }
        }
        .ToList();

        public IActionResult Index()
        {
            return View();
        }

        [Route("app/heroes")]
        public IActionResult HeroList()
        {
            return Ok(Heroes);
        }

        [HttpPut]
        [Route("app/heroes/{id:int}")]
        public IActionResult Update(int id,[FromBody]Hero hero)
        {
            var _hero = Heroes.FirstOrDefault(x => x.Id == id);
            if (_hero != null) _hero.Name = hero.Name;
            return Ok(_hero);
        }

        [HttpPost]
        [Route("app/heroes")]
        public IActionResult Add(string name)
        {
            var hero = new Hero { Id = Heroes.Count + 1, Name = name };
            Heroes.Add(hero);
            return Ok(hero);
        }

        [HttpDelete]
        [Route("app/heroes/{id:int}")]
        public IActionResult Delete(int id)
        {
            if (Heroes.RemoveAll(x => x.Id == id) > 0)
                return Ok(true);
            return Ok(false);
        }
    }

    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}