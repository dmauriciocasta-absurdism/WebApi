using System.ComponentModel.DataAnnotations;

namespace WebApi.DAL.Models.Dtos
{
    public class CategoryCreateDto
    {
        [Required (ErrorMessage = "El Nombre de la Categoria es Obligatorio")]
        public string Name { get; set; }
    }
}
