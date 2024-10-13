using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using materTestCore2.Helpers;
using static materTestCore2.Models.EGovModels.SharedClasses;

namespace materTestCore2.Security
{
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context != null)
            {
                var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
                string appName = Functions.appRouting( controllerActionDescriptor?.DisplayName.Split('.').ElementAt(2));
                string controllerName = controllerActionDescriptor?.ControllerName;
                string actionName = controllerActionDescriptor?.ActionName;
                string requiredPermission = string.Format("{0}_{1}_{2}", appName, controllerName, actionName);


                var claims = context.HttpContext.User.Claims;
                if (claims.Count() != 0)
                {
                    Claim userData = claims.First(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata");
                    List<string> permissions = userData.Value.Split('#').ToList();
                    if (!permissions.Contains(requiredPermission))
                    {
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "action", "UnauthorizedRequest" },
                    { "controller", "Account" },
                    { "returnUrl", "Login" },
                    { "authError", AuthError.NotEnaughPermissions },
                });

                    }
                }
                else
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "action", "UnauthorizedRequest" },
                    { "controller", "Account" },
                    { "returnUrl", "Login" },
                    { "authError", AuthError.SessionExpired },
                });

                }
                

            }
        }
    }
}
