using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DenemeProject.Controllers
{

    public class DefaultRouteFilter : ActionFilterAttribute
    {

    }
    public class BaseController : Controller
    {
        protected ActionExecutedContext _context;

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _context = context;
        }
    }
}
