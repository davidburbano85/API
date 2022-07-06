using System.ComponentModel.DataAnnotations;

namespace Metallica
{
    public abstract class ClasePadre
    {
        [Key]//atributos 
        public long Id { get; set; }//ESTO SI ES UNA VARIABLE LLAMADA Id entero de 64 bits en bd bigint
    }
}
