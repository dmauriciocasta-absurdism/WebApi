using System.ComponentModel.DataAnnotations;

namespace WebApi.DAL.Models
{
    public class AuditBase
    {
        [Key]//Cave primaria
        public virtual int id { get; set; }//clave primaria

        public virtual DateTime CreatedDate { get; set; }//fecha de creacion

        public virtual DateTime ModifiedDate { get; set; }//fecha de modificacion
    }
}
