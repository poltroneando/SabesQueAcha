using SabesQueAcha.Context;
using SabesQueAcha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SabesQueAcha.Controllers
{
    public class UsuariosController : Controller
    {

        public SabesContext Db = new SabesContext();

        // GET: Usuarios
        public ActionResult Cadastrar()
        {
            return View(new Usuario() { Lojista = new Lojista() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PreCadastro(Usuario usuario)
        {
            usuario.Lojista = new Lojista();
            return View("Cadastrar", usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Gravar(Usuario usuario, Lojista lojista = null)
        {
            try
            {

                Usuario UsuarioRetornado = Db.Usuario.Add(usuario);
                Db.SaveChanges();

                //if(usuario.FlagLoja && lojista != null)
                //{
                //    lojista.IdUsuario = UsuarioRetornado.IdUsuario;

                //    Db.Lojista.Add(lojista);
                //    Db.SaveChanges();
                //}

                TempData["UsuarioCadastrado"] = "Usuario cadastrado com sucesso. Faça Login para continuar";
                return RedirectToAction("Index", "Login");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                TempData["UsuarioCadastroErro"] = "Erro ao cadastrar usuário. Verifique as informações e tente novamente!";
                return View("Cadastrar", usuario);
            }
        }
    }
}