using MovieRentalManagementSystem.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieRentalManagementSystem.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]

        public DateTime ReleaseDate { get; set; }

        [Required]

        public DateTime AddedDate { get; set; }


        [Required]
        [Range(1, 20)]
        public int Stock { get; set; }

        public Genre Genre { get; set; }

        [Required]

        public int GenreId { get; set; }

        public string Title
        {
            get { return Id != 0 ? "Edit Movie" : "New Movie"; }
        }
    }
}