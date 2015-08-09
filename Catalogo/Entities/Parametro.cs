using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Catalogo.Entities
{
    [Table("tabpar", Schema = "cat")]
    public class Parametro
    {
        [Key]
        [Column("codpar")]
        public String Id { get; set; }

        [Column("nompar")]
        public String Nombre { get; set; }

        [Column("valpar")]
        public String Valor { get; set; }

        [Column("tippar")]
        public String Tipo { get; set; }

        [Column("estpar")]
        public String Estado { get; set; }

        [Column("grupar")]
        public String Grupo { get; set; }
    }
}