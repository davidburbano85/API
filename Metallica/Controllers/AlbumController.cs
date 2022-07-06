using Metallica.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Metallica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumController : ControllerBase//la clase principal lo demas para abajo son metodos CONTROLADOR
    {
        private readonly List<Album> listaAlbum;


        public AlbumController() // CONSTRUCTOR
        {
            listaAlbum = new List<Album>();
            var killEmAll = new Album
            {
                Id = 1,
                Nombre = "Kill Em All",
                Hits = 10,
                FechaDeLanzamiento = DateTime.Parse("25/07/1983")
            };

            var masterOfPuppets = new Album
            {
                Id = 2,
                Nombre = "Master of Puppets ",
                Hits = 9,
                FechaDeLanzamiento = DateTime.Parse("25/07/1987")
            };

            var rideTheLigthing = new Album
            {
                Id = 3,
                Nombre = "Ride the Ligthing ",
                Hits = 11,
                FechaDeLanzamiento = DateTime.Parse("25/07/1989"),
                ConBurton = false
            };

            listaAlbum.Add(killEmAll);//adicionamos instancia que en este caso es un objeto a la lista
            listaAlbum.Add(masterOfPuppets);
            listaAlbum.Add(rideTheLigthing);    

        }

        [HttpGet]//metodo de navegacion
        [Route("GetById/{Id}")]//ruta o direccion de la api web y recibe parametros {khgfkhg}
        public Album GetById(long Id)//esto es un maldito metodo publico que devuelve un string y recibe un long OBLIGATORIO LO QUE VA DENTRO DEL{} DEBE SER IGUAL AL PARAMETRO EN ESTE CASI Id
        {
            var model = listaAlbum.Find(x => x.Id == Id);//(x => x.Id == Id) funcion landa x hace referencia a un objeto
            return model;
            //return JsonConvert.SerializeObject(model);//retorna un objeto serializado en formato en esta ocasion JSON 
        }

        [HttpGet]
        [Route("traerTodaLaInfo")]//direccio api no recibe parametros
        public IEnumerable<Album> GetAll()// (IEnumerable es una lista de datos)creamos metodo vacio pero devuelve una lista de album en general seria de un tipo de objeto
        {

            return listaAlbum;//nos retorna directamente la lista
        }

        [HttpPost]//metodo de navegacion http que actualiza o crea 
        public string UpdateAlbum(Album model)//creamos metodo que me devuelve un string que recibe un parametro de tipo album en la variable  llamada model
        {
            //voy a la persistencia de datos es decir a la bd y actualizo y devuelvo el nuevo model
            return JsonConvert.SerializeObject(model);//nos retorna directamente el modelo que esta recibiendo por que no hay base de datos
        }
    }
}