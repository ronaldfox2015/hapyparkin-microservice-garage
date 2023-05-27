using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyParking.Entity
{
    [Table("tbusuario")]
    public partial class Usuario
    {
        [Key]
        [Column("idUsuario")]
        public Int64 IdUsuario { get; set; } = 0;
        [Column("correo")]
        public string Correo { get; set; } = "";
        [Column("clave")]
        public string Clave { get; set; } = "";
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
