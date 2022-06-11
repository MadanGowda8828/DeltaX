using DeltaX.Models;

namespace DeltaX.Repository
{
    /// <summary>
    /// Movie Repository Interface
    /// </summary>
    public interface IMovieRepository
    {
        //Delete Movie Async
        Task<int> DeleteMovieAsync(int id);
        //Add Movie Async
        Task<int> AddMovieAsync(MovieInfo movie);
        //Update Movie Async
        Task<int> UpdateMovieAsync(MovieInfo movie);
        //Get Movies Async
        Task<IEnumerable<MovieItem>> GetMoviesAsync();
    }
}
