using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChristmasPictureRater.Database;
using ChristmasPictureRater.Dtos;
using ChristmasPictureRater.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChristmasPictureRater.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PictureController : ControllerBase
    {
        private static List<string> Images = new List<string>();

        private readonly ILogger<PictureController> _logger;
        private readonly PictureRaterContext _db;

        public PictureController(ILogger<PictureController> logger, PictureRaterContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public DrawingDto[] Get()
        {
            return this._db.Drawings.Select(d => new DrawingDto(d)).ToArray();
        }

        [HttpGet]
        [Route("compare")]
        public RateDrawingsDto GetForRating()
        {
            //  var randomCategory = EnumHelper<Categories>.GetRandom();
            var allDrawings = _db.Drawings.Where(c => c.Category == Categories.Snowman).OrderBy(o => Guid.NewGuid())
                .Take(2)
                .ToArray();

            return new RateDrawingsDto(new DrawingDto(allDrawings[0]), new DrawingDto(allDrawings[1]));
        }


        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload([FromBody] Upload data)
        {
            this._db.Drawings.Add(new Drawing()
            {
                Image = data.Image,
                Category = Categories.Snowman,
                ArtistsName = "Unknown",
                CreatedDate = DateTime.Now
            });
            await this._db.SaveChangesAsync();
            return this.Ok();
        }

        [HttpPost]
        [Route("like/{id:int}")]
        public async Task<IActionResult> Like(int id)
        {
            var drawing = this._db.Drawings.First(d => d.Id == id);
            drawing.Likes++;
            await this._db.SaveChangesAsync();
            return this.Ok();
        }
    }

    public class Upload
    {
        public string Image { get; set; }
        public string ArtistName { get; set; }
    }

    public static class EnumHelper<T>
    {
        public static T GetRandom()
        {
            Array values = Enum.GetValues(typeof(T));
            Random random = new Random();
            T randomBar = (T) values.GetValue(random.Next(values.Length));
            return randomBar;
        }
    }
}