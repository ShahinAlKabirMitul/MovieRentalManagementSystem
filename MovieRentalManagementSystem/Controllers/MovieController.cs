using MovieRentalManagementSystem.Models;
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

        // GET: Movie
        public ActionResult Index()
        {
            // var movie = new Movie() { Name = "Boos Baby" };
            var movie = _context.Movie.Include(s => s.Genre).ToList();
            return View(movie);
        }
        public ActionResult Details(int id)
        {
            {

                var movie = _context.Movie.Include(s=>s.Genre).SingleOrDefault(c => c.Id == id);

                if (movie == null)
                    return HttpNotFound();

                return View(movie);

            }
        }

        public ActionResult Edit(int id)
        {
            return Content("Edit ID: " + id);
        }
    }
}