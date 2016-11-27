using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SabesQueAcha.Models
{
    public class Promocao
    {
        [Key]
        public int IdPromocao { get; set; }

        public int IdUsuario { get; set; }

        public int? IdLojista { get; set; }

        public int IdCategoria { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public string Foto { get; set; }

        public string UrlPromocao { get; set; }

        public DateTime DataPublicacao { get; set; }

        public bool FlagLoja { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Lojista Lojista { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}