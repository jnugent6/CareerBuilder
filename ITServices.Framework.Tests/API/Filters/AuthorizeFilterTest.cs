using System;
using System.IO;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using ITServices.Framework.API.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ITServices.Framework.Tests.API.Filters
{
    /// <summary>
    /// Summary description for AuthorizeFilterTest
    /// </summary>
    [TestClass]
    public class AuthorizeFilterTest
    {
      [TestMethod]
        public void AuthorizeFilter_OnExecutingAction_Test()
        {
            AuthorizeFilter authorizeFilter = new AuthorizeFilter();
         
            var httpControllerContext = new HttpControllerContext();
            httpControllerContext.Request = new HttpRequestMessage(HttpMethod.Get, "https://itservicestest.careerbuilder.com/accounts");
            httpControllerContext.Request.Headers.Add("Authorization", "Partner axiomcloud:3n81n3y@rd");
         
            var actionDescriptor = new ActionDescriptorMock(new ControllerDescriptorMock());
         
            var httpActionContext = new HttpActionContext(httpControllerContext,actionDescriptor)
            {
              ControllerContext = httpControllerContext ,
              ActionDescriptor = actionDescriptor
            };

            var controllerDescriptor = new ControllerDescriptorMock();
            controllerDescriptor.ControllerName = "Accounts";
            controllerDescriptor.ControllerType = this.GetType();
            httpActionContext.ActionDescriptor.ControllerDescriptor = controllerDescriptor;

            var request = new HttpRequest("", "http://tempuri.org", "");
           // request.
            //request.ServerVariables.Add("HTTP_RLNCLIENTIPADDR", "127.0.0.1");
            HttpContext.Current = new HttpContext(request,new HttpResponse(new StringWriter()));

              try
              {
                  authorizeFilter.OnActionExecuting(httpActionContext);
              }
              catch (Exception ex)
              {
              
                  Assert.AreEqual(ex.Message, "You are not authorized");
              }
            
        }
      
    }

    

    
}
