using _NET.Data;
using _NET.Dtos.Movie;
using _NET.models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using models;

namespace _NET.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private static List<Movie> movies = new List<Movie>
        {
            new Movie(),
            new Movie { Id = 1,Title = "1" }
        };
       
        
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public MovieService(IMapper mapper, DataContext context) {
            _mapper = mapper;
            _context = context;
        }


        public async Task<ServiceResponse<List<GetMovieDto>>> AddMovies(AddMovieDto newMovie)
        {
            var serviceResponse = new ServiceResponse<List<GetMovieDto>>();
            var movie = _mapper.Map<Movie>(newMovie);
           // movie.Id = movies.Max(x => x.Id) + 1;
            //movies.Add(movie);
            _context.movies.Add(movie);
            serviceResponse.Data = movies.Select(c => _mapper.Map<GetMovieDto>(c)).ToList();
            await _context.SaveChangesAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetMovieDto>>> DeleteMovieById(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetMovieDto>>();


            try
            {
                var dbMovies = await _context.movies.FirstOrDefaultAsync(c => c.Id == id);
                //var movie = movies.First(c => c.Id == id);
                if (dbMovies is null)
                {
                    throw new Exception($"Movie with ID '{id}' not found");
                }
                //movies.Remove(dbMovies);
                _context.movies.Remove(dbMovies);
                serviceResponse.Data = movies.Select(c => _mapper.Map<GetMovieDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }
            await _context.SaveChangesAsync();
            return serviceResponse;
        }



        public async Task<ServiceResponse<List<GetMovieDto>>> GetAllMovies()
        {
            var serviceResponse = new ServiceResponse<List<GetMovieDto>>();
            var dbMovies =  await _context.movies.ToListAsync();
            serviceResponse.Data = dbMovies.Select(c => _mapper.Map<GetMovieDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetMovieDto>> GetMovieById(int id)
        {
            var serviceResponse = new ServiceResponse<GetMovieDto>();
            var dbMovies = await _context.movies.FirstOrDefaultAsync(c => c.Id == id);
           // var movie= movies.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetMovieDto>(dbMovies);
            return serviceResponse;


        }

        public async Task<ServiceResponse<GetMovieDto>> UpdateMovie(UpdateMovieDto updatedMovie)
        {
            var serviceResponse = new ServiceResponse<GetMovieDto>();
            
            try
            {
                var dbMovies = await _context.movies.FirstOrDefaultAsync(c => c.Id == updatedMovie.Id);
                //var movie = movies.FirstOrDefault(c => c.Id == updatedMovie.Id);
                if(dbMovies == null)
                {
                    throw new Exception($"Movie with ID '{updatedMovie.Id}' not found");
                }

                _mapper.Map(updatedMovie, dbMovies);
               // movie.Title = updatedMovie.Title;
               // movie.ReleaseDate = updatedMovie.ReleaseDate;
               // movie.Genre = updatedMovie.Genre;
               // movie.Cast = updatedMovie.Cast;
               // movie.Lang = updatedMovie.Lang;
               // movie.Rating = updatedMovie.Rating;
               // movie.TreailerURL = updatedMovie.TreailerURL;

                serviceResponse.Data = _mapper.Map<GetMovieDto>(dbMovies);
            }catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }
            await _context.SaveChangesAsync();
            return serviceResponse;

        }

        
    }
}
