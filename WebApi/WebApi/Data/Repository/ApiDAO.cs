using Dapper;
using Microsoft.Data.SqlClient;
using WebApi.Domain.Models;
using System.Data.SqlClient;

namespace WebApi.Data.Repository
{
    public class ApiDAO
    {
        private readonly string _connectionString;

        // Injeção de IConfiguration no construtor
        public ApiDAO(IConfiguration configuration)
        {
            // Acessando a connectionString do appsettings.json
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public List<Cliente> BuscaTodosClientes()
        {
            var sql = $"select * from Clientes";
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    var clientes = db.Query<Cliente>(sql);
                    return clientes.ToList();
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao acessar o banco, Método: 'BuscaTodosClientes'");
            }  
        }
    }
}
