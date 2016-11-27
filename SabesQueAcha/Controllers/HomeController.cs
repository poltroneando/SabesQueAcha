using SabesQueAcha.Context;
using SabesQueAcha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SabesQueAcha.App_Start;
namespace SabesQueAcha.Controllers
{
    
    public class HomeController : Controller
    {
        public SabesContext Db = new SabesContext();

        // GET: LadingPage
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Nome,Email,Login,Senha")] Usuario u)
        {
            if (ModelState.IsValid)
            {
                Db.Usuario.Add(u);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult ListaCadastrada()
        {
            return View(Db.Usuario.ToList());
        }

    }
}