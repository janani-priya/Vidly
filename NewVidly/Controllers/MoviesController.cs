using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using NewVidly.Models;
using NewVidly.ViewModel;


namespace NewVidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {

           var movies= GetMovies().ToList();
            
           
            var randomMovieViewModel = new RandomMovieViewModel { 
              
                Movies= movies

            };

            return View(randomMovieViewModel);
        }

        //get:movies/ByReleaseDate
        [Route("movies/byreleasedate/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {

            return Content(year + "/" + month);
        }

        public IEnumerable<Movie> GetMovies()
        {
            Movie[] movies = new Movie[]{
                new Movie{Id = 1, Name = "Shrek"},
                new Movie { Id=2, Name = "Jurassic Park"}
            };

            return movies;
        }
    }
}