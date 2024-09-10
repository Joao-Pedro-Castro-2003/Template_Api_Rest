using Microsoft.AspNetCore.Mvc;
using WebApi.Business;
using WebApi.Domain.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class ApiController : Controller
    {
        //Variavel para ser usada na injeção de dependencia
        private readonly ApiBusiness _Bl;

        //Injeção de Dependencia para a Camada de Negócio
        public ApiController(ApiBusiness Bl)
        {
            _Bl = Bl;
        }

        [HttpGet]
        [Route("GetClientes")]
        public ActionResult<Cliente> BuscaTodosClientes()
        {
            try
            {
                var clientes = _Bl.BuscaTodosClientes();
                return Ok(clientes);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }    
        }
    }
}
