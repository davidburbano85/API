using Microsoft.AspNetCore.Mvc;//ruta de libreria
using Prueba2.Models;//ruta del proyecto

namespace Prueba2.Controllers//es la ruta de las carpetas
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase

    {
        private readonly List<Usuario> listaUsuario;

        public UsuariosController()
        {
            listaUsuario = new List<Usuario>();
            {
                Usuario davidBurbano = new()
                {
                    Id = 1,
                    Name = "Erwin David",
                    CellNumber = 3135181070,
                    Identify = 1085247277,
                    Married = true,
                    Position = "Mechatronic"

                };
                Usuario diegoBurbano = new()
                {
                    Id = 2,
                    Name = "Diego Vladimir",
                    CellNumber = 3137043757,
                    Identify = 1085247278,
                    Married = true,
                    Position = "Civil Enginner"
                };
                Usuario miguelAngel = new()
                {
                    Id = 3,
                    Name = "Miguel Angel",
                    CellNumber = 3163843784,
                    Identify = 1085247279,
                    Married = true,
                    Position = "Electronic Enginner"
                };
                listaUsuario.Add(davidBurbano);
                listaUsuario.Add(diegoBurbano);
                listaUsuario.Add(miguelAngel);

            }



        }


        //[HttpGet]
        //[Route("GetById/{Id}")]
        //public Usuario GetById(long Id)
        //{
        //    var user = listaUsuario.Find(x => x.Id == Id);
        //    return user;
        //}
        [HttpGet]
        [Route("GetByName")]
        public List <Usuario> GetByName(string? Nombre, string? Apellido, int? Cedula, long? Cel, bool? Casado, string? Papa, string? Mama, string? Cargo)//el signo significa que es opcional 
        {
            var dates = listaUsuario.FindAll(x => x.Name == Nombre || x.SurName == Apellido || x.Identify == Cedula || x.CellNumber == Cel || x.Married == Casado || x.Dad == Papa || x.Mom == Mama || x.Position == Cargo);
            return dates;
        }

        [HttpGet]
        [Route("GetById/{Id}")]
        public Usuario GetById(long Id)
        {
            var user = listaUsuario.Find(x => x.Id == Id);
            return user;
        }
    }
}
