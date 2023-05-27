using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyParking.Entity
{
    public class UsuarioResponse
    {
        public Int64 IdError { get; set; } = 0;
        public string Mensaje { get; set; } = "";
        public static Func<Usuario, UsuarioResponse> UsuarioToUsuarioResponse = e => new UsuarioResponse
        {
            IdError = e.Retorno?.IdError ?? 0,
            Mensaje = e.Retorno?.Mensaje ?? ""
        };
        
    }
}
