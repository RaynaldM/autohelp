using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace AutoHelp.Helpers
{
    public class ADAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var id = httpContext.User.Identity as System.Security.Principal.WindowsIdentity;
            if (id != null && id.Groups != null)
            {
                var authRole = WebConfigurationManager.AppSettings.Get("AuthorizedGroup");
                var readableGroups = id.Groups.Select(g => g.Translate(typeof(System.Security.Principal.NTAccount))).ToArray();
                var ret = readableGroups.Select(@group => @group.Value).Any(name => name == authRole);
                return ret;
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new ViewResult
               {
                   ViewName = "NotAuthorized",
                   MasterName = "_Layout"
               };
            }
            else
                base.HandleUnauthorizedRequest(filterContext);
        }
    }
}
