// Author: Sebastian Villafane Ramos
// Description: View Model for the Home Page

namespace Group8Project.Models.ViewModels
{
    public class HViewModel
    {
        public IEnumerable<Review>? Reviews { get; set; } = Enumerable.Empty<Review>();
        public String GetMovieName(int id)
        {
            Movie movie = Movies.FirstOrDefault(x => x.MovieId == id);

            return movie.Title;
        }
        public IEnumerable<Movie>? Movies{ get; set; } = Enumerable.Empty<Movie>();
    }
}
