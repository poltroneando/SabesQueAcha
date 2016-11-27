using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SabesQueAcha.App_Start
{
    public class SessionExpireFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;

            if (ctx.Session == null)
            {
                // check if a new session id was generated
                filterContext.Result = new RedirectResult("~/Login/Loggoff");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}