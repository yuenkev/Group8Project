// Author: Kevin Yuen
// Description: Interface for the Movie Repository

namespace Group8Project.Models
{
    public interface IMovieRepository
    {
        IQueryable<Movie> Movies { get; }
        public Movie addMovie(Movie mv);
        public void removeMovie(int id);
        Movie UpdateMovie(Movie mv);
        Movie GetMovieById(int id);


    }
}
