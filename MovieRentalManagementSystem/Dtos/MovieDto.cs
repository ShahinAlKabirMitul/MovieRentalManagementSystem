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
        public int Stock { get; set; }



        [Required]
        public int GenreId { get; set; }


    }
}