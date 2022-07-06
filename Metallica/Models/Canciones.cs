using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Metallica.Models
{
    public class Canciones : ClasePadre
    {
        public long IdAlbum { get; set; }//todas las canciones que pertenecen a cierto album
        public string Nombre { get; set; }
        public string LinkLetra { get; set; }
      
        public short Position { get; set; }


    }

    


}
