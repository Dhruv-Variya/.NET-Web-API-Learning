using _NET.Dtos.Movie;
using _NET.models;
using models;

namespace _NET.Services.MovieService
{
    public interface IMovieService
    {
        // task is for async
        Task<ServiceResponse<List<GetMovieDto>>> GetAllMovies();
        Task<ServiceResponse<GetMovieDto>> GetMovieById(int id);
        Task<ServiceResponse<List<GetMovieDto>>>AddMovies(AddMovieDto newMovie);
        Task<ServiceResponse<GetMovieDto>> UpdateMovie(UpdateMovieDto updatedMovie);
        Task<ServiceResponse<List<GetMovieDto>>> DeleteMovieById(int id);
    }
}
