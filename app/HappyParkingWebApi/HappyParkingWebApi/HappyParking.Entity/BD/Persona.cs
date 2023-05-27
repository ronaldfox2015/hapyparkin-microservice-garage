using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyParking.Entity
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
    }
}
