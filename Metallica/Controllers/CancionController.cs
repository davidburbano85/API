using Metallica.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Metallica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CancionController : ControllerBase
    {

        private readonly List<Canciones> listaCancion;//si no se agrega la ruta va a aaparecer como error namespace
        public CancionController()//este es un constructor que puede o no ser necesario
        {
            listaCancion = new List<Canciones>();
            var hitTheLight = new Canciones
            {
                Id = 1,
                Nombre = "Hit the Ligths",
                Position = 1,
                LinkLetra = "https://www.google.com/search?q=letra+de+hit+the+lights&rlz=1C1ALOY_esCO956CO956&oq=letra+de+hit+the+igtsh&aqs=chrome.1.69i57j0i13i30l3.12024j0j7&sourceid=chrome&ie=UTF-8",                
                IdAlbum = 1

            };

            Canciones motorbreat = new()//de esta manera tambien se crean instancias sin necesidad del maldito var
            {
                Id = 2,
                Nombre = "Motorbreath",
                Position = 2,
                LinkLetra = "https://www.google.com/search?q=letra+motorbreath+metallica&rlz=1C1ALOY_esCO956CO956&sxsrf=ALiCzsamMQnavIA73GDcQuHVtfA906AgJA%3A1654297827604&ei=45SaYsLOJKDLytMPlZeasA0&oq=letra+de+motorbre&gs_lcp=Cgdnd3Mtd2l6EAMYADIGCAAQHhAWOgcIABBHELADOgUIABCABDoICAAQsQMQgwE6CAgAEIAEELEDOgQIABADOgsIABCABBCxAxCDAToECAAQDToGCAAQHhANSgQIQRgASgQIRhgAUKcIWNYZYOYnaAFwAXgAgAG4AYgBlAmSAQMwLjiYAQCgAQHIAQfAAQE&sclient=gws-wiz",
                IdAlbum = 1
            };

            Canciones seekAndDestroy = new()
            {
                Id = 9,
                Nombre = "Seek and Destroid",
                Position = 9,
                LinkLetra = "https://www.google.com/search?q=letra+seek+and+destroy+metallica&rlz=1C1ALOY_esCO956CO956&sxsrf=ALiCzsbI58a9jmBMMjtFkY2kW2aADrm1yQ%3A1654298421538&ei=NZeaYvy9IKLAytMPqt6HkAQ&oq=letra+see+metallica&gs_lcp=Cgdnd3Mtd2l6EAMYADIGCAAQHhAHMggIABAeEAgQBzIICAAQHhAIEAc6BwgAEEcQsAM6BAgAEA1KBAhBGABKBAhGGABQ0QRY1Adg1BRoAXABeACAAb4BiAH1A5IBAzAuM5gBAKABAcgBBMABAQ&sclient=gws-wiz",              
                IdAlbum = 1
            };
            Canciones theCallOfKtullu = new()
            {
                Id = 8,
                Nombre = "The Call of Ktullu",
                Position = 8,
                LinkLetra = "",               
                IdAlbum = 3
            };
            Canciones one = new()
            {
                Id = 4,
                Nombre = "One",
                Position = 4,
                LinkLetra = "https://www.letraseningles.es/letrascanciones/traduccionesLO/Metallica-One-Traducida.html",                
                IdAlbum = 4
            };

            listaCancion.Add(hitTheLight);
            listaCancion.Add(one);
            listaCancion.Add(seekAndDestroy);
            listaCancion.Add(theCallOfKtullu);


        }

        [HttpGet]
        [Route("GetById/{Id}")]
        public Canciones GetById(long Id)
        {
            var song = listaCancion.Find(x => x.Id == Id);
            return song;
        }

        [HttpGet]
        [Route("allSongsInfo")]
        public IEnumerable<Canciones> GetAll()
        {
            return listaCancion;
        }

    }

}
