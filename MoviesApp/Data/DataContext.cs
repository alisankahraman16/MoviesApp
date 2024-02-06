using Microsoft.EntityFrameworkCore;

namespace MoviesApp.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}