using HappyParking.Entity;
using HappyParking.Infraestructure.Data;
using HappyParking.Infraestructure.Interface;
using MySql.Data.MySqlClient;
using System.Data;
using System.Reflection;
using Dapper;

namespace HappyParking.Infraestructure.Repository
{
    public class PersonaMySqlRepository : IPersonaMySqlRepository
    {
        private readonly IConnectionBD _connectionBD;
        public PersonaMySqlRepository(IConnectionBD connectionFactory)
        {
            _connectionBD = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
            
        }
        public Task<Persona> Actualizar(Persona entidad)
        {
            throw new NotImplementedException();
        }

        public Task<Persona> Eliminar(Persona entidad)
        {
            throw new NotImplementedException();
        }

        public Task<Persona> Insertar(Persona entidad)
        {
            throw new NotImplementedException();
        }

        public Task<List<Persona>> ObtenerPorConcepto(Persona entidad)
        {
            throw new NotImplementedException();
        }

        public Task<Persona> ObtenerPorPropiedad(Persona entidad)
        {
            throw new NotImplementedException();
        }
    }
}
