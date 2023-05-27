using System.ComponentModel.DataAnnotations;

namespace HappyParking.Entity
{
    public class UsuarioEliminarRequest
    {
        //[Required]
        //public Int64 IdUsuario { get; set; } = 0;
        [Required]
        public Int64 IdUsuarioModificacion { get; set; } = 0;

        public static Func<UsuarioEliminarRequest, Usuario> UsuarioEliminarRequestToUsuario = e => new Usuario
        {
            //IdUsuario = e.IdUsuario,
            IdUsuarioModificacion = e.IdUsuarioModificacion,
            Filtros = new ComunRequest(),
            Retorno = new RetornoResponse()
        };
    }
}
