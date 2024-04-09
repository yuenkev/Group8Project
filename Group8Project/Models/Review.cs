// Author: Murtaza Mian
// Description: Review Model


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group8Project.Models
{
    public class Review
    {
        [Key]
        public int RatingId { get; set; }

        [Required(ErrorMessage = "Please, enter a Movie ID.")]
        public int MovieId { get; set; }

        [Range(1, 10)]
        [Required(ErrorMessage = "Please enter a Score from 1-10.")]
        public double UserRating { get; set; }

        [Required(ErrorMessage = "Please enter a Review Description."), StringLength(500)]
        public string ReviewDescription { get; set; }

        [Required(ErrorMessage = "Please enter the Review Date.")]
        public DateTime DateRated { get; set; }

        [Required(ErrorMessage = "Please enter the Rater Name."), StringLength(100)]
        public string Rater { get; set; }
    }
}