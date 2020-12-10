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
            return this._db.Drawings.Select(d => new DrawingDto(d.Image, d.Category, d.ArtistsName, d.Likes)).ToArray();
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromBody] Upload data)
        {
            this._db.Drawings.Add(new Drawing()
            {
                Image = data.Img,
                Category = Categories.Snowman,
                ArtistsName = "Unknown"
            });
            await this._db.SaveChangesAsync();
            return this.Ok();
        }
    }

    public class Upload
    {
        public string Img { get; set; }
    }
}