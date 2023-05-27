using HappyParking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyParking.Infraestructure.Interface
{
    public interface IPersonaMySqlRepository
    {
        public Task<Persona> Insertar(Persona entidad);
        public Task<Persona> Actualizar(Persona entidad);
        public Task<Persona> Eliminar(Persona entidad);
        public Task<List<Persona>> ObtenerPorConcepto(Persona entidad);
        public Task<Persona> ObtenerPorPropiedad(Persona entidad);
    }
}
