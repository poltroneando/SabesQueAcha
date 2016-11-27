using SabesQueAcha.Context;
using SabesQueAcha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SabesQueAcha.Controllers
{
    public class PromocaoController : Controller
    {
        public SabesContext Db;

        // GET: Promocao
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Form()
        {
            return View();
        }


        //POST> /Promocao/Cadastrar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Promocao promocao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Db = new SabesContext();
                    Db.Promocao.Add(promocao);
                    Db.SaveChanges();

                    return Json(new { isok = true, message = "Promoção Cadastrada com sucesso!" });
                }
                else
                {
                    return Json(new { isok = false, message = "A promoção não está de acordo." });
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(new { isok = false, message = "Ocorreu um erro ao inserir no banco, tente novamente." });
            }
        }
    }
}