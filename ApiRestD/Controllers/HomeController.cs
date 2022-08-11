using Microsoft.AspNetCore.Mvc;
using Negocio;
using System.Data;
using Newtonsoft.Json;

namespace ApiRestD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Controller]
    public class HomeController : ControllerBase
    {
        static Bussines con = new Bussines();

        [HttpGet]
        [Route("Mostrar")]
        public string Mostrar()
        {
            List<ModelPilotos> Lista = con.Mostrar();
            var json = JsonConvert.SerializeObject(Lista);
            return json;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar(ModelPilotos pilotos)
        {
            string Respuesta = con.Insertar(pilotos.Nombre,pilotos.Escuderia,pilotos.Pais);
            return Respuesta;
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(ModelPilotos pilotos)
        {
            string Respuesta = con.Actualizar(pilotos.ID,pilotos.Nombre, pilotos.Escuderia, pilotos.Pais);
            return Respuesta;
        }

        [HttpDelete]
        [Route("Borrar/{Id}")]
        public string Borrar(int Id)
        {
            string Respuesta = con.Borrar(Id);
            return Respuesta;
        }

        [HttpGet]
        [Route("Buscar/{Id}")]
        public string BuscarID(int Id)
        {
            ModelPilotos Respuesta = con.BuscarID(Id);
            var json = JsonConvert.SerializeObject(Respuesta);
            return json;
        }
    }
}
