using MovieRentalManagementSystem.Models;
using MovieRentalManagementSystem.ViewModel;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MovieRentalManagementSystem.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool dispose)
        {
            _context.Dispose();
        }

        // GET: Movie
        public ActionResult Index()
        {
            // var movie = new Movie() { Name = "Boos Baby" };
            var movie = _context.Movie.Include(s => s.Genre).ToList();
            return View(movie);
        }

        public ActionResult New()
        {
            var viewModle = new MovieViewModel()
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModle);
        }

        public ActionResult Details(int id)
        {
            {

                var movie = _context.Movie.Include(s => s.Genre).SingleOrDefault(c => c.Id == id);

                if (movie == null)
                    return HttpNotFound();

                return View(movie);

            }
        }

        public ActionResult Edit(int id)
        {
            return Content("Edit ID: " + id);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            _context.Movie.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }
    }
}