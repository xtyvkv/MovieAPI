using MovieAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        MovieList DB = new MovieList();
       
        // Get a list of all movies
        [Route("SeeMovieList")]
        public Movie[] SeeMovieList()
        {
            return DB.Movies.ToArray();
        }

        // Get a list of all movies in a specific category
        [Route("MoviesByCategory")]
        public Movie[] MoviesByCategory(string chosenCategory)
        {
            var allMoviesOfCategory = new List<Movie>();
            foreach (var currMovie in DB.Movies)
            {
                Category currMovieCategory = null;
                foreach (var currCategory in DB.Categories)
                {
                    if (currCategory.Id == currMovie.CategoryId)
                    {
                        currMovieCategory = currCategory;
                        break;
                    }
                }
                if (currMovieCategory.CategoryName.Equals(chosenCategory, StringComparison.CurrentCultureIgnoreCase))
                    allMoviesOfCategory.Add(currMovie);
            }
            return allMoviesOfCategory.ToArray();
        }
        // Get a random movie pick
        [Route("RandomMovie")]
        public Movie RandomMovie()
        {
            Random randomMovie = new Random();
            int index = randomMovie.Next(DB.Movies.Count());
            return DB.Movies.ElementAt(index);
        }
        // Get a random movie pick from a specific category
        [Route("RandomMovieByCategory")]
        public Movie RandomMovie(string chosenCategory)
        {
            var allMoviesOfCategory = new List<Movie>();
            foreach (var currMovie in DB.Movies)
            {
                Category currMovieCategory = null;
                foreach (var currCategory in DB.Categories)
                {
                    if (currCategory.Id == currMovie.CategoryId)
                    {
                        currMovieCategory = currCategory;
                        break;
                    }
                }
                if (currMovieCategory.CategoryName.Equals(chosenCategory, StringComparison.CurrentCultureIgnoreCase))
                    allMoviesOfCategory.Add(currMovie);
            }
            Random randomMovie = new Random();
            int index = randomMovie.Next(allMoviesOfCategory.Count());
            return allMoviesOfCategory.ElementAt(index);
        }
        // Get a list of random movie picks (input quantity)
        // THIS WORKS BUT FIX DUPLICATES !!!
        // possible fix - first randomize movie list, then pick
        // creates new issue: what happens if qty exceeds number of movies?
        [Route("RandomMovieList")]
        public Movie[] RandomMovieList(int quantity)
        {
            // var randomMovieList = new List<Movie>();
            Random rnd = new Random();
            var randomMovieList = new List<Movie>();
            for (int i = 0; i<quantity; i++)
            {
                var index = rnd.Next(DB.Movies.Count);
                randomMovieList.Add(DB.Movies[index]);
            }

            return randomMovieList.ToArray();
        }
        // Get a list of all movie categories
        [Route("AllCategories")]
        public Category[] AllCategories()
        {
            var availableCategories = new List<Category>();
            foreach (var currMovieCategory in DB.Categories)
            {
                foreach (var currMovie in DB.Movies)
                {
                    if (currMovie.CategoryId == currMovieCategory.Id)
                    {
                        availableCategories.Add(currMovieCategory);
                        break;
                    }
                }
            }
            return availableCategories.ToArray();
        }
        // Get info about a specific movie (input title)
        [Route("InfoByTitle")]
        public Movie[] InfoByTitle(string titleInput)
        {
            var matchingTitle = new List<Movie>();
            foreach (var currMovie in DB.Movies)
            {
                if (titleInput.Equals(currMovie.Title, StringComparison.CurrentCultureIgnoreCase))
                    matchingTitle.Add(currMovie);
            }
            return matchingTitle.ToArray();
        }
        // Get a list of movies which have a keyword in their title
        [Route("ListByKeyword")]
        public Movie[] ListByKeyword(string keyword)
        {
            var matchingKeyword = new List<Movie>();
            foreach (var currMovie in DB.Movies)
            {
                if (currMovie.Title.Contains(keyword))
                    matchingKeyword.Add(currMovie);
            }
            return matchingKeyword.ToArray();
        }
    }
}
