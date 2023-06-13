using System.ComponentModel.DataAnnotations;

namespace CodingExercise.Models
{
    public class Rectangle
    {
        public Rectangle()
        {

        }
        public int RectangleId { get; set; }
        [Required]
        public int Length { get; set; }
        [Required]
        public int Width { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int Volume { get; set; }
    }
}
