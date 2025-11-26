using AutoMapper;
using WebApi.DAL.Models;
using WebApi.DAL.Models.Dtos;

namespace WebApi.MovieMapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, MovieCreateDto>().ReverseMap();
        }
    }
}
