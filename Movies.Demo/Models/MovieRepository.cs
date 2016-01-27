using System.Collections.Generic;

namespace Movies.Demo.Models
{
    public class MovieRepository : IMovieRepository
    {
        public IEnumerable<MovieEntity> Query()
        {
            return AppMovies.Movies;
        }
    }
}