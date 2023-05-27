using HappyParking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyParking.Infraestructure.Interface
{
    public interface IUsuarioMySqlRepository
    {
        public Task<Usuario> Insertar(Usuario entidad);
        public Task<Usuario> Actualizar(Usuario entidad);
        public Task<Usuario> Eliminar(Usuario entidad);
        public Task<List<Usuario>> ObtenerPorConcepto(Usuario entidad);
        public Task<Usuario> ObtenerPorPropiedad(Usuario entidad);
        public Task<Usuario> ValidaSesion(Usuario entidad);
    }
}
