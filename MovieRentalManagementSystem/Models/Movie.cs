﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MovieRentalManagementSystem.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Added Date")]
        public DateTime AddedDate { get; set; }

        [Display(Name = "Number Of Sotck")]
        [Required]
        public int Stock { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

    }
}