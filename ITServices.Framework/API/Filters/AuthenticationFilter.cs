using System;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using ITServices.Framework.Business;

namespace ITServices.Framework.API.Filters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var credentials = new Credentials();
            var dtoPartnerCredential = credentials.Get(actionContext);

            //Authentication
            IAuthenticationManager authenticationManager = new AuthenticationManager();
            bool isAuthenticated = authenticationManager.Authenticate(dtoPartnerCredential);

            if (!isAuthenticated)
            {
                throw new Exception("You are not authenticated or PartnerID/Password Invalid");
            }
        }
    }
}