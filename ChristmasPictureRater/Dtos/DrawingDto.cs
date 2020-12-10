using ChristmasPictureRater.Models;

namespace ChristmasPictureRater.Dtos
{
    public class DrawingDto
    {
        public DrawingDto(string image, Categories category, string artistsName, int likes)
        {
            Image = image;
            Category = category;
            ArtistsName = artistsName;
            Likes = likes;
        }
        public string Image { get; }
        public Categories Category { get; }
        public string ArtistsName { get; }
        public int Likes { get; }
    }
}