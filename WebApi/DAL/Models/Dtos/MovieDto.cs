using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace WebApi.DAL.Models.Dtos
{
    public class MovieDto
    {
        [Required(ErrorMessage = "La duración no puede ser Nula")]
      public int duration { get; set; }

        [Required(ErrorMessage = "Debe contener Clasificación")]
        [MaxLength(100, ErrorMessage = "El Nombre de la clasisifiación NO debe exceder los 10 caracteres")]]
    public string classification { get; set; }

        [Required(ErrorMessage = "La pelicula Debe contener Nombre")]
        [MaxLength(100, ErrorMessage = "El Nombre no debe exceder los 100 caracteres")]]
    public string name { get; set; }
    }
}
