namespace ChristmasPictureRater.Models
{
    public class Drawing
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public Categories Category { get; set; }
        public string ArtistsName { get; set; }
        public int Likes { get; set; }
    }

    public enum Categories
    {
        Snowman,
        ChristmasTree,
        Santa
    }
}