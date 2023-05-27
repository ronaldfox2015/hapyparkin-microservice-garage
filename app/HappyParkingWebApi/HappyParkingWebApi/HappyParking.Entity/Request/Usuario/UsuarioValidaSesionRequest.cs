using System.ComponentModel;

namespace HappyParking.Entity
{
    public class UsuarioValidaSesionRequest
    {
        [DefaultValue("")]
        public string Correo { get; set; } = "";
        [DefaultValue("")]
        public string Clave { get; set; } = "";
        public int IdRol { get; set; } = 0;
        public static Func<UsuarioValidaSesionRequest, Usuario> UsuarioInsertarRequestToUsuario = e => new Usuario
        {
            Correo = e.Correo,
            Clave = e.Clave,
            Estado = e.IdRol,
            Filtros = new ComunRequest(),
            Retorno = new RetornoResponse()

        };
    }
}
