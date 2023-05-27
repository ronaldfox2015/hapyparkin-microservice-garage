using HappyParking.Domain.Entity;

namespace HappyParking.Application.Entity
{
    public class UsuarioObtenerPorPropiedadResponse
    {
        public Int64 IdUsuario { get; set; } = 0;
        public string Correo { get; set; } = "";
        public string Clave { get; set; } = "";
        public string FechaCreacion { get; set; } = "";
        public Int64 IdUsuarioModificacion { get; set; } = 0;
        public string FechaActualizacion { get; set; } = "";
        public int Estado { get; set; } = 0;
        public static Func<Usuario, UsuarioObtenerPorConceptoResponse> UsuarioToUsuarioObtenerPorConceptoResponse = e => new UsuarioObtenerPorConceptoResponse
        {
            IdUsuario = e.IdUsuario,
            Correo = e.Correo,
            Clave = e.Clave,
            FechaCreacion = e.FechaCreacion,
            IdUsuarioModificacion = e.IdUsuarioModificacion,
            FechaActualizacion = e.FechaActualizacion,
            Estado = e.Estado
        };
        
    }
}
