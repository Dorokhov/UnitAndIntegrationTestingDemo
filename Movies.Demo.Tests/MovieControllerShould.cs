using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Moq;
using Movies.Demo.Controllers;
using Movies.Demo.Models;
using Xunit;

namespace Movies.Demo.Tests
{
    public class MovieControllerShould
    {
        [Fact]
        public void Return_List_Of_Movies_Ordered_By_Release_Date()
        {
            // arrange
            var repoMock = new Mock<IMovieRepository>();
            repoMock
                .Setup(x => x.Query())
                .Returns(AppMovies.Movies);
            var movieController = new MovieController(repoMock.Object);

            // act 
            ViewResult view = movieController.Movies() as ViewResult;

            // assert
            view.Model.Should().BeOfType(typeof(List<MovieEntity>));
            var model = view.Model as List<MovieEntity>;
            model[0].ShouldBeEquivalentTo(AppMovies.EmpireStrikesBack);
            model[1].ShouldBeEquivalentTo(AppMovies.NewHope);
        }
    }
}
