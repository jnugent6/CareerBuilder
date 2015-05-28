using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using ITServices.Framework.API.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ITServices.Framework.Tests.API.Filters
{
    /// <summary>
    /// Summary description for AuthorizeFilterTest
    /// </summary>
    [TestClass]
    public class AuthenticationFilterTest
    {
      [TestMethod]
        public void AuthenticationFilter_OnExecutingAction_Test()
        {
            AuthenticationFilter authenticationFilter = new AuthenticationFilter();
         
            var httpControllerContext = new HttpControllerContext();
            httpControllerContext.Request = new HttpRequestMessage(HttpMethod.Get, "https://itservicestest.careerbuilder.com/accounts");
            httpControllerContext.Request.Headers.Add("Authorization", "Partner axiomcloud:3n81n3y@rd");
            var actionDescriptor = new ActionDescriptorMock();
            var httpActionContext = new HttpActionContext(httpControllerContext,actionDescriptor);

            authenticationFilter.OnActionExecuting(httpActionContext);
        }

        [TestMethod]
        public void AuthenticationFilter_OnExecutingAction_MissingHeaders_Test()
        {
            AuthenticationFilter authenticationFilter = new AuthenticationFilter();
            var httpControllerContext = new HttpControllerContext();
            httpControllerContext.Request = new HttpRequestMessage(HttpMethod.Get, "https://itservicestest.careerbuilder.com/accounts");
            var actionDescriptor = new ActionDescriptorMock();
            var httpActionContext = new HttpActionContext(httpControllerContext, actionDescriptor);
            try
            {
                authenticationFilter.OnActionExecuting(httpActionContext);
            }
            catch (Exception ex)
            {

                Assert.AreEqual(ex.Message, "Request missing Authorization Headers");
            }
       
        }

        [TestMethod]
        public void AuthenticationFilter_OnExecutingAction_InvalidPartner_Test()
        {
            AuthenticationFilter authenticationFilter = new AuthenticationFilter();
            var httpControllerContext = new HttpControllerContext();
            httpControllerContext.Request = new HttpRequestMessage(HttpMethod.Get, "https://itservicestest.careerbuilder.com/accounts");
            httpControllerContext.Request.Headers.Add("Authorization", "Partner axiomcloud:test123");
            var actionDescriptor = new ActionDescriptorMock();
            var httpActionContext = new HttpActionContext(httpControllerContext, actionDescriptor);
            try
            {
                authenticationFilter.OnActionExecuting(httpActionContext);
            }
            catch (Exception ex)
            {

                Assert.AreEqual(ex.Message, "You are not authenticated or PartnerID/Password Invalid");
            }

        }
    }

}
