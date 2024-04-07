using System.Diagnostics;

namespace Group8Project.Models.ViewModels
{
    public class MViewModel
    {
        public IEnumerable<Movie>? Movies { get; set; } = Enumerable.Empty<Movie>();
        public Movie? tempMovie { get; set; } = new Movie();
    }
}
