using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metallica.Models
{

    public class Album : ClasePadre//claseeees se tiene q instanciar
    {
        #region Constructor

        public Album()//constructoooor
        {
            ConBurton = true;
            BuenoMalo = 'B';
        }
        #endregion

        #region Propiedades o campos(bd) o variables

        public string Nombre { get; set; }//cadenas en bd varchar(100 )
        public char BuenoMalo { get; set; }//un caracter alfanumerico y se denota con una sola comilla ''
        public int Hits { get; set; }//entero de 32 bits de 
        public DateTime FechaDeLanzamiento { get; set; }//fechas
        public bool ConBurton { get; set; }//booleano en bd tipo bit


        #endregion

        #region Metodos

        public void miMetodo()
        {
            Nombre.Concat("lo que queira");
        }
        #endregion

    }
}
