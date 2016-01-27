using System;

namespace Movies.Demo.Models
{
    public class MovieEntity
    {
        private static DateTime _minReleaseDate = new DateTime(1900, 01, 01);
        
        public MovieEntity(string name, string description, DateTime releaseDate, string[] genres)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Specify param", nameof(name));
            }

            if (releaseDate < _minReleaseDate)
            {
                throw new ArgumentException("Specify param", nameof(releaseDate));
            }

            Name = name;
            Description = description;
            ReleaseDate = releaseDate;
            Genres = genres;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string[] Genres { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MovieEntity) obj);
        }

        protected bool Equals(MovieEntity other)
        {
            return string.Equals(Name, other.Name);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}