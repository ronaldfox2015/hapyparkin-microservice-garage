using HappyParking.Domain.Entity;

namespace HappyParking.Application.Entity
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
