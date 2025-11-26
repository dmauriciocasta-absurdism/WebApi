using System.ComponentModel.DataAnnotations;

namespace WebApi.DAL.Models
{
    public class Movie : AuditBase
    {
        [Required]
        public String Name { get; set; }//Almacena nombre movie

        public int Duration { get; set; }//Almacena duracion movie en minutos

        public string Description { get; set; }//Almacena descripcion movie

        public string classification { get; set; }//Almacena clasificacion movie

        public string Genre { get; set; }//Almacena genero movie

    }
}
