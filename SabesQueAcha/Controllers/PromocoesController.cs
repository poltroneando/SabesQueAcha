using SabesQueAcha.Context;
using SabesQueAcha.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace SabesQueAcha.Controllers
{
    public class PromocoesController : Controller
    {
        public SabesContext Db = new SabesContext();

        // GET: Promocoes
        public ActionResult Index(int? CategoriaId)
        {
            List<Promocao> Promocoes;

            if (CategoriaId.HasValue)
            {
                Promocoes = Db.Promocao.Where(var => var.IdCategoria == CategoriaId.Value).ToList();
            }
            else
            {
                Promocoes = Db.Promocao.ToList();
            }

            ViewBag.SelectedCategoria = CategoriaId ?? 0;

            if (Session["Categorias"] == null)
            {
                Session["Categorias"] = Db.Categoria.ToList();
            }

            return View(Promocoes);
        }

        [Authorize]
        public ActionResult Cadastrar()
        {
            return View(Db.Categoria.ToList());
        }

        [Authorize]
        [HttpPost]
        public ActionResult SalvarPromocao(Promocao p)
        {
            try
            {
                if(Session["UsuarioId"] == null)
                {
                    TempData["UsuarioCadastrado"] = "Sessão expirou. Faça Login para continuar navegando!";
                    return RedirectToAction("Loggoff", "Login");
                }

                if (ModelState.IsValid)
                {
                    p.DataPublicacao = DateTime.Now;
                    p.IdUsuario = Int32.Parse(Session["UsuarioId"].ToString());

                    if(p.FlagLoja)
                    {
                        p.IdLojista = Int32.Parse(Session["LojistaId"].ToString());
                    }

                    var Promocao = Db.Promocao.Add(p);
                    Db.SaveChanges();

                    if (Promocao != null)
                    {
                        return Json(new { sucesso = true, mensagem = "Promoção Cadastrada com Sucesso!" });
                    }
                }

                return Json(new { sucesso = false, mensagem = "Algo deu errado!" });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(new { sucesso = false, mensagem = "Erro ao adicionar a Promoção! Verifique as informações e tente novamente!" });
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult AdicionarComentario(Comentario comentario)
        {
            try
            {
                if (Session["UsuarioId"] == null)
                {
                    TempData["UsuarioCadastrado"] = "Sessão expirou. Faça Login para continuar navegando!";
                    return RedirectToAction("Loggoff", "Login");
                }

                comentario.IdUsuario = Int32.Parse(Session["UsuarioId"].ToString());
                comentario.DataComentario = DateTime.Now;

                Db.Comentario.Add(comentario);
                Db.SaveChanges();

                comentario.Usuario = Db.Usuario.Where(var => var.IdUsuario == comentario.IdUsuario).FirstOrDefault();

                return PartialView("_Comentario", comentario);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Content("Erro ao cadastrar comentario.", MediaTypeNames.Text.Plain);
            }
        }

        [HttpGet]
        public ActionResult _Comentarios(int PromocaoId)
        {
            try
            {
                TempData["PromocaoId"] = PromocaoId;
                return PartialView(Db.Comentario.Where(var => var.IdPromocao == PromocaoId).ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Content("Erro ao obter comentarios.", MediaTypeNames.Text.Plain);
            }
        }

    }
}