namespace CodingExercise.Models
{
    public class RectangleResponse
    {
        public RectangleResponse()
        {
            LengthMatchedRectangles = new List<Rectangle>();
            WidthMatchedRectangles = new List<Rectangle>();
            HeightMatchedRectangles = new List<Rectangle>();
            VolumneMatchedRectangles = new List<Rectangle>();
        }
        public List<Rectangle> LengthMatchedRectangles { get; set; }
        public List<Rectangle> WidthMatchedRectangles { get; set; }
        public List<Rectangle> HeightMatchedRectangles { get; set; }
        public List<Rectangle> VolumneMatchedRectangles { get; set; }
    }
}
