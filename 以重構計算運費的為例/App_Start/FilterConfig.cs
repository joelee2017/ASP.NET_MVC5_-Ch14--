using System.Web;
using System.Web.Mvc;

namespace 以重構計算運費的為例
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
