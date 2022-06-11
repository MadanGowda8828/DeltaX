using DeltaX.Models;
using DeltaX.Repository;

namespace DeltaX.Services
{
    /// <summary>
    /// Movie Service
    /// </summary>
    public class MovieService: IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        /// <summary>
        /// delete Movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns>int</returns>
        public async Task<int> DeleteMovieService(int id)
        {
            int res = await _movieRepository.DeleteMovieAsync(id);
            return res; 
        }
        /// <summary>
        /// Add Movie Service
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>movie Id</returns>
        public async Task<int> AddMovieService(Movie movie)
        {
            MovieInfo movieInfo = new MovieInfo();
            movieInfo.PosterName = movie.Poster.FileName;
            movieInfo.Name = movie.Name;
            movieInfo.Plot = movie.Plot;
            movieInfo.Date = movie.Date;
            movieInfo.Producer = movie.Producer;
            movieInfo.Actors = movie.Actors+",";
            using var fileStream = movie.Poster.OpenReadStream();
            long length = movie.Poster.Length;
            byte[] bytes = new byte[length];
            fileStream.Read(bytes, 0, (int)movie.Poster.Length);
            movieInfo.PosterData = bytes;
            int res = await _movieRepository.AddMovieAsync(movieInfo);
            return res;
        }
        /// <summary>
        /// Update Movie Service
        /// </summary>
        /// <param name="movie"></param>
        /// <param name="id"></param>
        /// <returns>int </returns>
        public async Task<int> UpdateMovieService(Movie movie, int id)
        {
            MovieInfo movieInfo = new MovieInfo();
            movieInfo.Id = id;
            movieInfo.PosterName = movie.Poster.FileName;
            movieInfo.Name = movie.Name;
            movieInfo.Plot = movie.Plot;
            movieInfo.Date = movie.Date;
            movieInfo.Producer = movie.Producer;
            movieInfo.Actors = movie.Actors + ",";
            using var fileStream = movie.Poster.OpenReadStream();
            long length = movie.Poster.Length;
            byte[] bytes = new byte[length];
            fileStream.Read(bytes, 0, (int)movie.Poster.Length);
            movieInfo.PosterData = bytes;
            int res = await _movieRepository.UpdateMovieAsync(movieInfo);
            return res;
        }
        /// <summary>
        /// Get Movies List Service
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MovieItem>> GetMoviesService()
        {
            var res = await _movieRepository.GetMoviesAsync();
            return res;
        }
    }
}
