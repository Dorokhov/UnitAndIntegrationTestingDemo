using System.Collections.Generic;

namespace Movies.Demo.Models
{
    public interface IMovieRepository
    {
        IEnumerable<MovieEntity> Query();
    }
}