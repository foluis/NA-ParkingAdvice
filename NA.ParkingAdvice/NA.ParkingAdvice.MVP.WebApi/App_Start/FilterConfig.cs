using System.Web;
using System.Web.Mvc;

namespace NA.ParkingAdvice.MVP.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
