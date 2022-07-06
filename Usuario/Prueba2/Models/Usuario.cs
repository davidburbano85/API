namespace Prueba2.Models
{
    public class Usuario : ClasePadre
    {
        public Usuario()
        {
            Dad = "Ferney Burbano";
            Mom = "Mila Realpe";
            SurName = "Burbano Realpe";
        }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Identify { get; set; }
        public long CellNumber { get; set; }
        public bool Married { get; set; }
        public string Dad { get; set; }
        public string Mom { get; set; }
        public string Position { get; set; }


    }


}
