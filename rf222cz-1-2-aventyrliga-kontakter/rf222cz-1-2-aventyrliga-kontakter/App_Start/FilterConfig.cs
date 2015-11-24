using System.Web;
using System.Web.Mvc;

namespace rf222cz_1_2_aventyrliga_kontakter
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
