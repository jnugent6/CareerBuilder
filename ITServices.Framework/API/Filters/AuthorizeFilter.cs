namespace ITServices.Framework.API.Filters
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using ITServices.Framework.Business;
    using ITServices.Framework.DTO;

    public class AuthorizeFilter : ActionFilterAttribute
    {
        private void LogEvent(HttpActionContext actionContext)
        {
            string request = actionContext.Request.ToString();
            string[] requestArray = request.Split(new[] { '\r', '\n' })
                        .Select(line => line.Contains("Authorization") ? "........." : line).ToArray();
            string formatted_request = string.Join(".", requestArray);

            var credentials = new Credentials();
            var dtoPartnerCredential = credentials.Get(actionContext);

            System.IO.Directory.CreateDirectory(@"D:\apilogs\");

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\apilogs\logs.txt", true))
            {
                string logevent = "~~~CorrelationID: " + actionContext.Request.GetCorrelationId().ToString() + "~";
                logevent += "Request: " + formatted_request + "~";
                logevent += "PartnerID: " + dtoPartnerCredential.PartnerID + "~";
                if (HttpContext.Current != null)
                    logevent += "IPAddress: " + GetClientIPAddress(HttpContext.Current.Request) + "~";
                logevent += "WebServiceName: " + actionContext.ActionDescriptor.ControllerDescriptor.ControllerName + "~";
                logevent += "WebMethodName: " + actionContext.ActionDescriptor.ActionName + "~";
                if (actionContext.Response != null)
                {
                    logevent += "ResponseStatusCode: " + actionContext.Response.StatusCode.GetHashCode() + "~";
                    logevent += "ResponseVersion: " + actionContext.Response.Version + "~";
                    logevent += "ResponseContent: " + actionContext.Response.Content + "~";
                    logevent += "ResponseHeaders: " + actionContext.Response.Headers + "~";
                }
                else
                {
                    logevent += "ResponseStatusCode: ~ResponseVersion: ~ResponseContent: ~ResponseHeaders: ~";
                }
                logevent += "Timestamp: " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff");
                file.WriteLine(logevent);
            }
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            LogEvent(actionContext);
            var credentials = new Credentials();
            var dtoPartnerCredential = credentials.Get(actionContext);

            var dtoPartnerWsRequest = SetPartnerWSRequest(actionContext, dtoPartnerCredential);

            //Authorization
            IAuthorizeManager authManager = new AuthorizeManager();
            bool IsAuthorized = authManager.Authorize(dtoPartnerWsRequest);

            if (!IsAuthorized)
            {
                throw new Exception("You are not authorized");
            }
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            LogEvent(actionExecutedContext.ActionContext);
            base.OnActionExecuted(actionExecutedContext);
        }

        private DTOPartnerWSRequest SetPartnerWSRequest(HttpActionContext actionContext, DTOPartnerCredential dtoPartnerCredential)
        {
            DTOPartnerWSRequest dtoPartnerWsRequest = new DTOPartnerWSRequest();
            if (HttpContext.Current != null)
                dtoPartnerWsRequest.ClientIPAddress = GetClientIPAddress(HttpContext.Current.Request);
            dtoPartnerWsRequest.PartnerCredential = dtoPartnerCredential;
            dtoPartnerWsRequest.SystemName = GetSystemName(actionContext);
            dtoPartnerWsRequest.WebServiceName = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            dtoPartnerWsRequest.WebMethodName = actionContext.ActionDescriptor.ActionName;
            return dtoPartnerWsRequest;
        }

        private string GetSystemName(HttpActionContext actionContext)
        {
            string SystemFullName = (actionContext.ActionDescriptor.ControllerDescriptor.ControllerType).FullName;
            int i = SystemFullName.IndexOf('.');

            return SystemFullName.Substring(0, i);
        }

        protected string GetClientIPAddress(HttpRequest oRequest)
        {
            string sClientIPAddress = "";
            sClientIPAddress = oRequest.ServerVariables["HTTP_RLNCLIENTIPADDR"];
            if (string.IsNullOrEmpty(sClientIPAddress))
            {
                sClientIPAddress = oRequest.UserHostAddress;
            }
            return sClientIPAddress;
        }
    }
}