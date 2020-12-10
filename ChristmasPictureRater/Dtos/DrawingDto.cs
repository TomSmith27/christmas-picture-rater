using ChristmasPictureRater.Models;

namespace ChristmasPictureRater.Dtos
{
    public class DrawingDto
    {
        public DrawingDto(int id, string image, Categories category, string artistsName, int likes)
        {
            Id = id;
            Image = image;
            Category = category;
            ArtistsName = artistsName;
            Likes = likes;
        }

        public DrawingDto(Drawing drawing) : this(drawing.Id, drawing.Image, drawing.Category, drawing.ArtistsName,
            drawing.Likes)
        {
        }

        public int Id { get; }
        public string Image { get; }
        public Categories Category { get; }
        public string ArtistsName { get; }
        public int Likes { get; }
    }


    public class RateDrawingsDto
    {
        public RateDrawingsDto(DrawingDto drawing1, DrawingDto drawing2)
        {
            Drawing1 = drawing1;
            Drawing2 = drawing2;
        }

        public DrawingDto Drawing1 { get; }
        public DrawingDto Drawing2 { get; }
    }
}