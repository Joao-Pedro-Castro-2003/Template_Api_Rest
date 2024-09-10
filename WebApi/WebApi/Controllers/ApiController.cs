using Microsoft.AspNetCore.Mvc;
using WebApi.Business;
using WebApi.Domain.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class ApiController : Controller
    {
        //Variavel para ser usada na inje��o de dependencia
        private readonly ApiBusiness _Bl;

        //Inje��o de Dependencia para a Camada de Neg�cio
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
