using System.ComponentModel.DataAnnotations;

namespace WebApi.DAL.Models
{
    public class Category : AuditBase
    {
        [Required]//Indica que el campo es obligatorio
        public String Name { get; set; }//Almacena nombre de la categoria
    }
}
