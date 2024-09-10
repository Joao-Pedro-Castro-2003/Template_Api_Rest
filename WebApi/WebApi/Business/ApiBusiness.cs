using WebApi.Data.Repository;
using WebApi.Domain.Models;

namespace WebApi.Business
{
    public class ApiBusiness
    {
        private readonly ApiDAO _apiDAO;

        public ApiBusiness(ApiDAO apiDAO)
        {
            _apiDAO = apiDAO;
        }

        public List<Cliente> BuscaTodosClientes()
        {
            var clientes = _apiDAO.BuscaTodosClientes();
            if (clientes.Count.Equals(0))
            {
                throw new Exception("Não foram encontrados clientes");
            }
            return clientes;
        }
    }
}
