using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;


namespace MoviesApp.Controllers
{
    public class MovieController: Controller
    {
        private readonly DataContext _context;

        public MovieController(DataContext context)
        {
            _context = context;
            
        }
        public async Task<IActionResult> Index()
        {
            var Movies = await _context.Movies.ToListAsync();
            return View(Movies);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie model)
        {
            _context.Movies.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var mov = await _context.Movies.FindAsync(id);

            if(mov == null)
            {
                return NotFound();
            }

            return View(mov);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Movie model)

        {
            if(id != model.MovieId)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!_context.Movies.Any(m => m.MovieId == model.MovieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            
            if(movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if(movie == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var movie = await _context.Movies.FindAsync(id);

            if(movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
    }
}