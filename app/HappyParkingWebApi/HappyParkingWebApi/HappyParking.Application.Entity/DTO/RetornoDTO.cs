using HappyParking.Domain.Entity;

namespace HappyParking.Application.Entity
{
    public class RetornoDTO
    {
        public Int64 IdError { get; set; } = 0;
        public string Mensaje { get; set; } = "";
        public static Func<RetornoResponse, RetornoDTO> RetornoResponseToDTO = e => new RetornoDTO
        {
            IdError = e.IdError,
            Mensaje = e.Mensaje
        };
    }
}
