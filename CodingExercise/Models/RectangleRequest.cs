using System.ComponentModel.DataAnnotations;

namespace CodingExercise.Models
{
    public class RectangleRequest
    {
        [Required]
        public int Length { get; set; }
        [Required]
        public int Width { get; set; }
        [Required]
        public int Height { get; set; }
    }
}
