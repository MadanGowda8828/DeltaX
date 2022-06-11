using DeltaX.Models;
using DeltaX.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeltaX.Controllers
{
    /// <summary>
    /// Movies Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        /// <summary>
        /// Add Movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>Success or Failure</returns>
        [HttpPost]
        public async Task<ActionResult> AddMovie([FromForm] Movie movie)
        {
            long length = movie.Poster.Length;
            if (length < 0)
            {
                return BadRequest();
            }
            int res = await _movieService.AddMovieService(movie);
            if (res == 0)
            {
                return Ok("Failed to add the Movie.");
            }
            return Ok("Movie added successfully.");
        }
        /// <summary>
        /// Update Movie
        /// </summary>
        /// <param name="movie"></param>
        /// <param name="id"></param>
        /// <returns>success or failure</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMovie([FromForm] Movie movie, [FromRoute] int id)
        {
            long length = movie.Poster.Length;
            if (length < 0 || id == 0)
            {
                return BadRequest();
            }
            int res = await _movieService.UpdateMovieService(movie, id);
            if (res == 0)
            {
                return Ok("Failed to update the Movie or Particular Movie Not Found");
            }
            return Ok("Movie updated successfully.");
        }
        /// <summary>
        /// Get Movies List
        /// </summary>
        /// <returns>List of Movies</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieItem>>> GetMoviesList()
        {
            var res = await _movieService.GetMoviesService();
            if (!res.Any())
            {
                return NoContent();
            }
            else
            {
                return Ok(res);
            }
        }
        /// <summary>
        /// Delete Movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Success or Failure</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie([FromRoute] int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            int res = await _movieService.DeleteMovieService(id);
            if(res == 0)
            {
                return Ok("Failed to Delete the Movie or Particular movie not found");
            }
            return Ok("Movie Deleted Successfully");
        }
    }
}
