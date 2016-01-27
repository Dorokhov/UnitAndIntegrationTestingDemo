using FluentAssertions;
using FluentAutomation;
using Xunit;
using System.Linq;
using Movies.Demo.Models;

namespace Movies.Demo.Tests
{
    public class MovieControllerIntegrationTests : FluentTest
    {
        public MovieControllerIntegrationTests()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);
        }

        [Fact]
        public void User_Should_Be_Able_To_See_Movies_List()
        {
            I.Open("http://localhost:55740/Movie/Movies");
            I.Expect.Class("table");
            I.FindMultiple(".table tr").Elements.Count.Should().Be(AppMovies.Movies.Count());
        }
    }
}