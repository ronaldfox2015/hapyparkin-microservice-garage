using System.ComponentModel;

namespace HappyParking.Entity
{
    public class UsuarioInsertarRequest
    {
        [DefaultValue("")]
        public string Correo { get; set; } = "";
        [DefaultValue("")]
        public string Clave { get; set; } = "";
        public int Estado { get; set; } = 0;
        public static Func<UsuarioInsertarRequest, Usuario> UsuarioInsertarRequestToUsuario = e => new Usuario
        {
            Correo = e.Correo,
            Clave = e.Clave,
            Estado = e.Estado,
            Filtros = new ComunRequest(),
            Retorno = new RetornoResponse()

        };
    }
}
