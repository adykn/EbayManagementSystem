using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EMSc.Helpers
{
    public class toNameHelpers 
    {
        public static IHtmlString toName(string Name)
        {
            string str = Name.Substring(0, 1).ToUpper() + Name.Substring(1, Name.Length - 1).ToLower();
            return MvcHtmlString.Create(str.ToString());
        }
    }

}