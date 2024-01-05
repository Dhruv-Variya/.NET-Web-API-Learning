using _NET.Dtos.Movie;
using AutoMapper;
using models;

namespace _NET
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Movie, GetMovieDto>();
            CreateMap<AddMovieDto, Movie>();
            CreateMap<UpdateMovieDto, Movie>();
        }
    }
}
 