using WebApi.DAL.Models;

namespace WebApi.Repository.IRepository
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>>GetMoviesAsync();//Retorna la coleccion de peliculas

        Task<Movie?>GetMovieByIdAsync(int Id);//Retorna una pelicula por id

        Task<bool> CreateMovieAsync(Movie movie);//Crea una pelicula

        Task<bool> UpdateMovieAsync(Movie movie);//Actualiza una pelicula

        Task<bool> DeleteMovieAsync(int Id);//Elimina una pelicula
    }
}
