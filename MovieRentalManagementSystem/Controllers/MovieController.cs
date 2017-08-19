using MovieRentalManagementSystem.Models;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MovieRentalManagementSystem.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            var movie = new Movie() { Name = "Boos Baby" };
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            return  Content("Edit ID: "+id);
        }
    }
}