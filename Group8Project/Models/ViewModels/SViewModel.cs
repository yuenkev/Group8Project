// Author: Kevin Yuen
// Description: View Model for the Search Page

namespace Group8Project.Models.ViewModels
{
    public class SViewModel
    {
        public IEnumerable<Review>? Reviews { get; set; } = Enumerable.Empty<Review>();
    }
}
