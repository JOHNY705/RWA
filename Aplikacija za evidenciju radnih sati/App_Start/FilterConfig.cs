using System.Web;
using System.Web.Mvc;

namespace Aplikacija_za_evidenciju_radnih_sati
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
