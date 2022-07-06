using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController1 : ControllerBase
    {
      
        public List<Usuario> Get()
        {
            return UsuarioData.listar();

        }
        
        public Usuario Get(int Id)
        {
            return UsuarioData.Obtener(Id);
        }
        
        public bool Post([FromBody]Usuario usuario)
        {
            return UsuarioData.Registrar(usuario); 
        }
        
        public bool Put([FromBody] Usuario usuario)
        {
           return UsuarioData.Modificar(usuario);
        }
        public bool Delete(int Id)
        {
            return UsuarioData.Eliminar(Id);
        }
    }
}
