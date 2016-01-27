using System.Linq;
using FluentAssertions;
using Movies.Demo.Models;
using Xunit;

namespace Movies.Demo.Tests
{
    public class MovieRepositoryShould
    {
        [Fact]
        public void Return_Two_Movies_By_Default()
        {
            // arrange
            MovieRepository movieRepository = new MovieRepository();

            // act
            var movies = movieRepository.Query();

            // assert
            movies.Should().HaveCount(AppMovies.Movies.Count());
        }
    }
}