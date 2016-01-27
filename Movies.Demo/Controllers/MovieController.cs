using System.Linq;
using System.Web.Mvc;
using Movies.Demo.Models;

namespace Movies.Demo.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _repository;

        public MovieController(IMovieRepository repository)
        {
            _repository = repository;
        }
        
        public ActionResult Movies()
        {
            var movies = _repository.Query().OrderByDescending(x => x.ReleaseDate).ToList();
            return View(movies);
        }
    }
}