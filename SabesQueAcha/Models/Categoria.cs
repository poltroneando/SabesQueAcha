﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SabesQueAcha.Models
{
    public class Categoria
    {
        public int IdCategoria { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<Promocao> Promocoes { get; set; }
    }
}