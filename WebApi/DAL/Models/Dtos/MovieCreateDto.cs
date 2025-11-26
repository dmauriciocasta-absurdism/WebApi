using System.ComponentModel.DataAnnotations;

namespace WebApi.DAL.Models.Dtos
{
    public class MovieCreateDto
    {
        [Required(ErrorMessage = "La pelicula Debe contener Nombre")]
        [MaxLength(100, ErrorMessage = "El Nombre no debe exceder los 100 caracteres")]]
        public string Name { get; set; }
    }
}
