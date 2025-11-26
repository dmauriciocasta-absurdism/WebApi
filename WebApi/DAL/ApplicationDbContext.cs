using Microsoft.EntityFrameworkCore;
using WebApi.DAL.Models;

namespace WebApi.DAL
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)//Metodo constructor
        {

            
        }
          
    public DbSet<Category> Categories { get; set; }//Propiedad para acceder a la tabla Categories
    public DbSet<Movie> Movies { get; set; }//Propiedad para acceder a la tabla Movies
    }
}
