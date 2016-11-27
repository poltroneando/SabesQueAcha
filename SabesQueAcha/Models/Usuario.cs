using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SabesQueAcha.Models
{
    public class Usuario
    {
        [Key]               
        public int IdUsuario { get; set; }
                
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Foto { get; set; }

        public string Login { get; set; }

        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public bool FlagLoja { get; set; }

        public virtual Lojista Lojista { get; set; }

        public virtual ICollection<Promocao> Promocoes { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }

        public static string[] UsuarioLogado
        {
            get
            {
                return HttpContext.Current.User.Identity.Name.Split('|');
            }
        }

    }
}