using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace SabesQueAcha
{
    public class ObjectContextPerHttpRequest
    {
        public static SabesQueAcha.Context.SabesContext Context
        {
            get
            {
                string objectContextKey = HttpContext.Current.GetHashCode().ToString("x");
                if (!HttpContext.Current.Items.Contains(objectContextKey))
                {
                    HttpContext.Current.Items.Add(objectContextKey, new SabesQueAcha.Context.SabesContext());
                }
                return HttpContext.Current.Items[objectContextKey] as SabesQueAcha.Context.SabesContext;
            }
        }        
    }
}