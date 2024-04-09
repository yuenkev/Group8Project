// Author: Murtaza Mian
// Description: View Model for the Review Page

namespace Group8Project.Models.ViewModels
{
    public class RViewModel
    {
        //public Movie? Movie { get; set; } = new Movie();
        public IEnumerable<Movie>? Movies { get; set; } = Enumerable.Empty<Movie>();
        public IEnumerable<Review>? Reviews { get; set; } = Enumerable.Empty<Review>();
        public int MovieId { get; set; }
        public Review? tempReview { get; set; } = new Review() { DateRated = DateTime.Now };
    }
}