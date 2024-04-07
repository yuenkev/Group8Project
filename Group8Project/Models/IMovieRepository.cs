namespace Group8Project.Models
{
    public interface IMovieRepository
    {
        IQueryable<Movie> Movies { get; }
        public void addMovie(Movie mv);
    }
}
