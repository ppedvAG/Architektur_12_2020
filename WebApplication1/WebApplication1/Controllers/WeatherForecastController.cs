using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}


        static List<Pizza> db = new List<Pizza>();

        public WeatherForecastController()
        {
            db.Add(new Pizza() { Id = 1, Name = "Salami", Preis = 6.67m });
            db.Add(new Pizza() { Id = 2, Name = "Schinken", Preis = 9.67m });
            db.Add(new Pizza() { Id = 3, Name = "Schlumpf", Preis = 19.67m });
        }

        [HttpGet]
        public IEnumerable<Pizza> Get()
        {
            return db;
        }

        [HttpPost]
        public void AddPizza(Pizza p)
        {
            db.Add(p);
        }

    }

    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Preis { get; set; }
    }
}
