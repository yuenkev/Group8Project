namespace Group8Project.Models
{
    public interface IMovieRepository
    {
        IQueryable<Movie> Movies { get; }
        public Movie addMovie(Movie mv);
        public void removeMovie(int id);
        Movie UpdateMovie(Movie movie);
        Movie GetMovieById(int id);


    }
}
