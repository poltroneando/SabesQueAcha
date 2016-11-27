using SabesQueAcha.Context;
using SabesQueAcha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SabesQueAcha.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public SabesContext Db = new SabesContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(Usuario u)
        {
            if (u != null)
            {
                if (ModelState.IsValid)
                {
                    Usuario user = Db.Usuario.Where(x => x.Login == u.Login && x.Senha == u.Senha).FirstOrDefault();
                    if (user != null)
                    {
                        FormsAuthentication.Initialize();
                        FormsAuthentication.HashPasswordForStoringInConfigFile(user.Senha, "md5"); // Or "sha1"

                        // Create a new ticket used for authentication
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                           1, // Ticket version
                           user.Login, // Username associated with ticket
                           DateTime.Now, // Date/time issued
                           DateTime.Now.AddMinutes(60), // Date/time to expire
                           true, // "true" for a persistent user cookie
                           user.FlagLoja ? "Lojista" : "User", // User-data, in this case the roles
                           FormsAuthentication.FormsCookiePath);// Path cookie valid for

                        // Encrypt the cookie using the machine key for secure transport
                        string hash = FormsAuthentication.Encrypt(ticket);
                        HttpCookie cookie = new HttpCookie(
                           FormsAuthentication.FormsCookieName, // Name of auth cookie
                           hash); // Hashed ticket

                        // Set the cookie's expiration time to the tickets expiration time
                        if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;

                        // Add the cookie to the list for outgoing response
                        Response.Cookies.Add(cookie);

                        Session["UsuarioId"] = user.IdUsuario;

                        if (user.FlagLoja)
                        {
                            Session["LojistaId"] = user.Lojista.IdLojista;
                        }

                        return RedirectToAction("Index", "Promocoes");
                    }
                }
                return View(u);
            }
            return View();
        }

        [Authorize]
        public ActionResult Loggoff()
        {

            Session.RemoveAll();
            Session.Abandon();
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}