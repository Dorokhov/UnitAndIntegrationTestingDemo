using System;
using System.Collections.Generic;

namespace Movies.Demo.Models
{
    public class AppMovies
    {
        public static MovieEntity NewHope
        {
            get
            {
                return new MovieEntity(
                    "Star Wars Episode IV: A New Hope",
                    "Luke Skywalker begins a journey that will change the galaxy, as he leaves his home planet, battles the evil Empire, and learns the ways of the Force",
                    new DateTime(1977, 05, 25),
                    new[] {"Fantasy"});
            }
        }

        public static MovieEntity EmpireStrikesBack
        {
            get
            {
                return new MovieEntity(
                    "Star Wars Episode V: The Empire Strikes Back",
                    @"After the destruction of the Death Star, the Empire has regrouped -- with Darth Vader leading the hunt for Luke Skywalker.",
                    new DateTime(1980, 05, 21),
                    new[] {"Fantasy"});
            }
        }

        public static IEnumerable<MovieEntity> Movies
        {
            get
            {
                yield return NewHope;
                yield return EmpireStrikesBack;
            }
        }
    }
}