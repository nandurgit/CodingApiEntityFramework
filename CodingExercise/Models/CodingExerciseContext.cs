using Microsoft.EntityFrameworkCore;

namespace CodingExercise.Models
{
    public class CodingExerciseContext:DbContext
    {
        public CodingExerciseContext(DbContextOptions<CodingExerciseContext> options) : base(options)
        {

        }
        public DbSet<Rectangle> Rectangles { get; set; }
    }
}
