using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChristmasPictureRater.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Images = new List<string>();

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Images;
        }

        [HttpPost]
        public IActionResult Upload([FromBody] Upload data)
        {
            Images.Add(data.Img);
            return Ok();
        }
    }

    public class Upload
    {
        public string Img { get; set; }
    }
}