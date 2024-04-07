namespace Group8Project.Models.ViewModels
{
    public class RViewModel
    {
        //public Movie? Movie { get; set; } = new Movie();
        public IEnumerable<Movie>? Movies { get; set; } = Enumerable.Empty<Movie>();
        public IEnumerable<Review>? Reviews { get; set; } = Enumerable.Empty<Review>();
        public Review? tempReview { get; set; } = new Review();
    }
}
