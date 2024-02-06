using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Data
{
    public class Movie
    {
        [Display(Name ="Id")]
        public int MovieId { get; set; }
        [Display(Name ="Title")]
        public string MovieTitle { get; set; } = null!;
        [Display(Name ="Poster")]
        public string Image { get; set; } = null!;
        [Display(Name ="Genre")]
        public string MovieGenre { get; set; } = null!;
        [Display(Name ="Rating")]
        public double MovieRate { get; set; }
        
    }
}