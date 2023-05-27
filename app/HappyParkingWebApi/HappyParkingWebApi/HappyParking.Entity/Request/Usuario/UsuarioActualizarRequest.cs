using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HappyParking.Entity
{
    public class UsuarioActualizarRequest
    {
        //[Required]
        //public Int64 IdUsuario { get; set; } = 0;
        [DefaultValue("")]
        public string Clave { get; set; } = "";
        [Required]
        public Int64 IdUsuarioModificacion { get; set; } = 0;
        public int Estado { get; set; } = 0;

        public static Func<UsuarioActualizarRequest, Usuario> UsuarioActualizarRequestToUsuario = e => new Usuario
        {
            //IdUsuario = e.IdUsuario,
            Clave = e.Clave,
            IdUsuarioModificacion= e.IdUsuarioModificacion,
            Estado = e.Estado,
            Filtros = new ComunRequest(),
            Retorno = new RetornoResponse()
        };
    }
}
