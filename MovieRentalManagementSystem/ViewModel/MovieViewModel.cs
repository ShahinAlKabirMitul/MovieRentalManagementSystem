using MovieRentalManagementSystem.Models;
using System.Collections.Generic;

namespace MovieRentalManagementSystem.ViewModel
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}