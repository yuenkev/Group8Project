// Author: Kevin Yuen
// Description: Implements all the IMovie Repository Interface methods

namespace Group8Project.Models
{
    public class EFMovieRepository : IMovieRepository
    {
        private MBS_DBContext context;
        public EFMovieRepository(MBS_DBContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Movie> Movies => context.Movies;
        public Movie addMovie(Movie mv)
        {
            // Add new movie to the database
            context.Movies.Add(mv);
            context.SaveChanges();

            return mv;

        }
        public Movie UpdateMovie(Movie mv)
        {
            var existingMovie = context.Movies.FirstOrDefault(m => m.MovieId == mv.MovieId);

            if (existingMovie != null)
            {
                // Update existing user properties
                existingMovie.Title = mv.Title;
                existingMovie.Description = mv.Description;
                existingMovie.Genre = mv.Genre;
                existingMovie.Director = mv.Director;
                existingMovie.Runtime = mv.Runtime;
                existingMovie.ReleaseDate = mv.ReleaseDate;

                // Save changes to the existing user
                context.SaveChanges();

                return existingMovie;
            }

            return null;
        }

        public void removeMovie(int id)
        {
            var movieToRemove = context.Movies.FirstOrDefault(m => m.MovieId == id);

            if (movieToRemove != null)
            {
                context.Movies.Remove(movieToRemove);
                context.SaveChanges();
            }
        }

        public Movie GetMovieById(int id) { 
            return context.Movies.FirstOrDefault(m => m.MovieId == id);
        }

    }
}
