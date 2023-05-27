using HappyParking.Domain.Entity;
using System.ComponentModel.DataAnnotations;
namespace HappyParking.Application.Entity
{
    public class UsuarioEliminarFilter
    {
        //[Required]
        //public Int64 IdUsuario { get; set; } = 0;
        [Required]
        public Int64 IdUsuarioModificacion { get; set; } = 0;

        public static Func<UsuarioEliminarFilter, Usuario> UsuarioEliminarRequestToUsuario = e => new Usuario
        {
            //IdUsuario = e.IdUsuario,
            IdUsuarioModificacion = e.IdUsuarioModificacion,
            Filtros = new ComunRequest(),
            Retorno = new RetornoResponse()
        };
    }
}
