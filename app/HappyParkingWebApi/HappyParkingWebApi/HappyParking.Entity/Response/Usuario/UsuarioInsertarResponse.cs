using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyParking.Entity
{
    public class UsuarioInsertarResponse
    {
        public Int64 IdUsuario { get; set; } = 0;
        public Int64 IdError { get; set; } = 0;
        public string Mensaje { get; set; } = "";
        public static Func<Usuario, UsuarioInsertarResponse> UsuarioToUsuarioInsertarResponse = e => new UsuarioInsertarResponse
        {
            IdUsuario = e.IdUsuario,
            IdError = e.Retorno?.IdError ?? 0,
            Mensaje = e.Retorno?.Mensaje ?? ""
        };
        
    }
}
