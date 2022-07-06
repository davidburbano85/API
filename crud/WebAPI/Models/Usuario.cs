namespace WebAPI.Models
{
    public class Usuario//es un objeto con variables aunque puede tener metodos propiedades
    {
        public int IdUsuario { get; set; }//ESTAS SON PROPIEDADES
        public string DocumentoIdentidad { get; set; }
        public int Nombres { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Ciudad { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
