using System.ComponentModel.DataAnnotations;

namespace Prueba2.Models
{
    public abstract class ClasePadre
    {
        [Key]
        public long Id { get; set; }

    }
}
