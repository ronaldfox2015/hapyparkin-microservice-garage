using HappyParking.Domain.Entity;
using System.ComponentModel;
namespace HappyParking.Application.Entity
{
    public class UsuarioObtenerPorConceptoFilter
    {
        public Int64 IdUsuario { get; set; } = 0;
        public Int64 IdUsuarioModificacion { get; set; } = 0;
        public int Estado { get; set; } = 0;
        [DefaultValue("")]
        public string FechaInicio { get; set; } = "";
        [DefaultValue("")]
        public string FechaFin { get; set; } = "";

        public static Func<UsuarioObtenerPorConceptoFilter, Usuario> UsuarioObtenerPorConceptoRequestToUsuario = e => new Usuario
        {
            IdUsuario = e.IdUsuario,
            IdUsuarioModificacion = e.IdUsuarioModificacion,
            Estado = e.Estado,
            Filtros = new ComunRequest {
                FechaInicio = e.FechaInicio,
                FechaFin = e.FechaFin
            },
            Retorno = new RetornoResponse()
        };
    }
}
