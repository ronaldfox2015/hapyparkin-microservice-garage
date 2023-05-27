using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyParking.Domain.Entity
{
    [Table("tbpersona")]
    public class Persona
    {
        [Key]
        [Column("idPersona")]
        public int idPersona { get; set; } = 0;
        [Column("idUsuario")]
        public int idUsuario { get; set; } = 0;
        [Column("nombres")]
        public string nombres { get; set; } = "";
        [Column("fechaCreacion")]
        public string FechaCreacion { get; set; } = "";
        [Column("idUsuarioModificacion")]
        public Int64 IdUsuarioModificacion { get; set; } = 0;
        [Column("fechaActualizacion")]
        public string FechaActualizacion { get; set; } = "";
        [Column("estado")]
        public int Estado { get; set; } = 0;
        public RetornoResponse? Retorno { get; set; }
        public ComunRequest? Filtros { get; set; }

    }
}
