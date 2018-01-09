using System.Web;
using System.Web.Mvc;
using ToDo.Web.Logging;

namespace ToDo.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthorizeAttribute()); 
           // filters.Add(new ToDoAppHandleErrorAttribute());
            //filters.Add(new HandleErrorAttribute());
        }
    }
}
