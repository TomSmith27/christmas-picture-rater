using System;

namespace ChristmasPictureRater.Models
{
    public class Drawing
    {
        public int Id { get; set; }
        public string Image { get; set; } = string.Empty;
        public Categories Category { get; set; }
        public string ArtistsName { get; set; } = string.Empty;
        public int Likes { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public enum Categories
    {
        Snowman,
        ChristmasTree,
        Santa
    }
}