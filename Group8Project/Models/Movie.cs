﻿// Author: Kevin Yuen   
// Description: Movie Model

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group8Project.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a Description."), StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a Genre.")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Please enter the Director's Name"), StringLength(100)]
        public string Director { get; set; }

        [Required(ErrorMessage = "Please enter the Movie Duration/Runtime.")]
        public TimeSpan Runtime { get; set; }

        [Required(ErrorMessage = "Please enter the Release Date.")]
        public DateTime ReleaseDate { get; set; }
    }
}