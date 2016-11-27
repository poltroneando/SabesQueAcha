using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SabesQueAcha.Models
{
    public class Comentario
    {
        [Key]
        public int IdComentario { get; set; }
        public int IdPromocao { get; set; }

        public int IdUsuario { get; set; }

        public string Descricao { get; set; }

        public DateTime DataComentario { get; set; }

        public virtual Promocao Promocao { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}