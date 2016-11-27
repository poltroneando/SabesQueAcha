using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SabesQueAcha.Util
{
    public static class CookieManager
    {
        private static string ckUsuario = Encoder.MD5Encoder("IdUsuario");

        public static int UsuarioId
        {
            get { return Int32.Parse(HttpContext.Current.Request.Cookies[ckUsuario].Value); }
            set { HttpContext.Current.Request.Cookies[ckUsuario].Value = value.ToString();  }
        }

        private static string ckLojista = Encoder.MD5Encoder("IdLojista");

        public static int LojistaId
        {
            get { return Int32.Parse(HttpContext.Current.Request.Cookies[ckLojista].Value); }
            set { HttpContext.Current.Request.Cookies[ckLojista].Value = value.ToString(); }
        }
    }
}   