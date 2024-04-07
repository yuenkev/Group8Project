namespace Group8Project.Models
{
    public class EFMovieRepository : IMovieRepository
    {
        private MBS_DBContext context;
        public EFMovieRepository(MBS_DBContext ctx)
        {
            context = ctx;
        }

        public void addMovie(Movie mv)
        {
            context.Movies.Add(mv);
            context.SaveChanges();
        }
        public IQueryable<Movie> Movies => context.Movies;
    }
}
