using AutoMapper;
using MovieRentalManagementSystem.Dtos;
using MovieRentalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace MovieRentalManagementSystem.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public IEnumerable<MovieDto> GetMovies()
        {
            var movies = _dbContext.Movie.ToList();
            var data = movies.Select(Mapper.Map<Movie, MovieDto>);
            return data;
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _dbContext.Movie.SingleOrDefault(s => s.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto MovieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(MovieDto);
            _dbContext.Movie.Add(movie);
            _dbContext.SaveChanges();
            MovieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);
        }

        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieDb = _dbContext.Movie.SingleOrDefault(s => s.Id == id);
            if (movieDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(movieDto, movieDb);

            _dbContext.SaveChanges();
        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieDb = _dbContext.Movie.SingleOrDefault(s => s.Id == id);
            if (movieDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _dbContext.Movie.Remove(movieDb);
            _dbContext.SaveChanges();

        }
    }
}
