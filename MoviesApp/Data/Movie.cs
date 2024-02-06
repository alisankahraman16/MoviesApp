namespace MoviesApp.Data
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; } = null!;
        public string MovieGenre { get; set; } = null!;
        public double MovieRate { get; set; }
        
    }
}