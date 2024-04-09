// Author: Kevin Yuen 
// Description: API Controller for the Movie Entity

using Microsoft.AspNetCore.Mvc;
using Group8Project.Models;
using System.Collections.Generic;

namespace Group8Project.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieAPIController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MovieAPIController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // GET: api/MovieAPI
        [HttpGet]
        public IEnumerable<Models.Movie> Get() => _movieRepository.Movies;

        // GET: api/MovieAPI/{id}
        [HttpGet("{id}")]
        public ActionResult<Models.Movie> GetMovieById(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return BadRequest("Movie ID cannot be null or empty.");
            }

            var movie = _movieRepository.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }


        [HttpPost]
        public Models.Movie Post([FromBody] Models.Movie movie) =>
            _movieRepository.addMovie(new Models.Movie
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                Director = movie.Director,
                Runtime = movie.Runtime,
                ReleaseDate = movie.ReleaseDate
            });

        [HttpPut]
        public Models.Movie Put([FromBody] Models.Movie movie) =>
            _movieRepository.UpdateMovie(movie);

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _movieRepository.removeMovie(id);
        }

    }

}
