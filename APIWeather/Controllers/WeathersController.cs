using APIWeather.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIWeather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeathersController : ControllerBase
    {
        WeatherContext context = new WeatherContext();

        [HttpGet]
        public IActionResult WeatherCityList()
        {
            var cities = context.Cities.ToList();
            if (cities.Count == 0)
            {
                return NotFound("No cities found.");
            }
            return Ok(cities);
        }

        [HttpPost]
        public IActionResult CreateWeatherCity([FromBody] Entities.City city)
        {
            if (city == null)
            {
                return BadRequest("City data is null.");
            }
            context.Cities.Add(city);
            context.SaveChanges();
            return CreatedAtAction(nameof(WeatherCityList), new { id = city.CityId }, city);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWeatherCity(int id)
        {
            var city = context.Cities.Find(id);
            if (city == null)
            {
                return NotFound($"City with ID {id} not found.");
            }
            context.Cities.Remove(city);
            context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateWeatherCity(int id, [FromBody] Entities.City updatedCity)
        {
            if (updatedCity == null)
            {
                return BadRequest("Updated city data is null.");
            }
            var city = context.Cities.Find(id);
            if (city == null)
            {
                return NotFound($"City with ID {id} not found.");
            }
            city.CityName = updatedCity.CityName;
            city.Country = updatedCity.Country;
            city.Temperature = updatedCity.Temperature;
            city.WeatherDescription = updatedCity.WeatherDescription;
            context.SaveChanges();
            return NoContent();
        }

        [HttpGet("GetByIdWeatherCity")]
        public IActionResult GetByIdWeatherCity(int id)
        {
            var city = context.Cities.Find(id);
            if (city == null)
            {
                return NotFound($"City with ID {id} not found.");
            }
            return Ok(city);

        }

        [HttpGet("TotalCityCount")]
        public IActionResult TotalCityCount()
        {
            var count = context.Cities.Count();
            return Ok(new { TotalCities = count });

        }

        [HttpGet("MaxTempCity")]
        public IActionResult MaxTempCity()
        {
            var maxTempCity = context.Cities.OrderByDescending(c => c.Temperature).FirstOrDefault();
            if (maxTempCity == null)
            {
                return NotFound("No cities found.");
            }
            return Ok(maxTempCity);

        }
    }
}
