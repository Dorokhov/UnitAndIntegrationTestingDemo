using System;
using FluentAssertions;
using Movies.Demo.Models;
using Xunit;

namespace Movies.Demo.Tests
{
    public class MovieEntityShould
    {
        [Fact]
        public void Include_General_Information_About_A_Movie()
        {
            // arrange
            var starWarsName = "STAR WARS: EPISODE VI RETURN OF THE JEDI";
            var starWarsDescription = "Luke Skywalker heads a mission to rescue Han Solo from the clutches of Jabba the Hutt, and faces Darth Vader one last time.";
            var releaseDate = new DateTime(1983, 05, 25);
            var genres = new string[] { "Sci-Fi", "Fantasy" };

            // act
            var starWarsMovie = new MovieEntity(starWarsName, starWarsDescription, releaseDate, genres);

            // assert
            starWarsMovie.Name.Should().Be(starWarsName, "name mismatch");
            starWarsMovie.Description.Should().Be(starWarsDescription, "description mismatch");
            starWarsMovie.ReleaseDate.Should().Be(releaseDate, "release date mismatch");
            starWarsMovie.Genres.ShouldBeEquivalentTo(genres, "genres mismatch");
        }

        [Fact]
        public void Throw_ArgumentException_If_Name_Is_Not_Specified()
        {
            // arrange
            string movieName = null;
            string description = "Movie description";
            var releaseDate = new DateTime(1983, 05, 25);
            var genres = new string[] { "Fantasy" };

            // act
            Action act = () => new MovieEntity(movieName, description, releaseDate, genres);

            // arrange
            act.ShouldThrow<ArgumentException>()
                .And.ParamName.Should().Be("name");
        }

        [Fact]
        public void Throw_ArgumentException_If_Release_Date_Is_Earlier_1900()
        {
            // arrange
            string movieName = "movie";
            string description = "movie description";
            DateTime releaseDate = new DateTime(1899, 12, 31);
            string[] genres = null;

            // act
            Action act = () => new MovieEntity(movieName, description, releaseDate, genres);

            // assert
            act.ShouldThrow<ArgumentException>()
                .And.ParamName.Should().Be("releaseDate");
        }

        [Fact]
        public void Be_Equal_If_Their_Names_Are_Equal()
        {
            // arrange
            string movieName = "movie";

            var movie1 = new MovieEntity(movieName, "description", new DateTime(1999, 12, 31), new[] { "Fantasy" });
            var movie2 = new MovieEntity(movieName, null, new DateTime(1999, 12, 30), new[] { "Sci-Fi" });

            // act
            var equals = movie1.Equals(movie2);

            // assert
            equals.Should().BeTrue();
        }
    }
}