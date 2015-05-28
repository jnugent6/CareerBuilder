using ITServices.Framework.Business;
using ITServices.Framework.Data;
using ITServices.Framework.DTO;
using ITServices.Framework.Tests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ITServices.Framework.Tests.Business
{
    /// <summary>
    /// Summary description for AuthorizeManagerTest
    /// </summary>
    [TestClass]
    public class AuthorizeManagerTest 
    {
       [TestMethod]
        public void AuthorizeTest()
        {
           DTOPartnerWSRequest  dtoPartnerWsRequest = new DTOPartnerWSRequest();
           DTOPartnerCredential dtoPartnerCredential = new DTOPartnerCredential();
           dtoPartnerCredential.PartnerID = "AxiomCloud";
           dtoPartnerWsRequest.PartnerCredential = dtoPartnerCredential;
           dtoPartnerWsRequest.ClientIPAddress = "127.0.0.1";
           dtoPartnerWsRequest.SystemName = "ITServices";
           dtoPartnerWsRequest.WebServiceName = "Accounts";
           dtoPartnerWsRequest.WebMethodName = "Get";
           IUnitOfWork unitOfWork = new UnitOfWorkMock();
           IAuthorizeManager authorizeManager = new AuthorizeManager(unitOfWork);

           Assert.IsTrue(authorizeManager.Authorize(dtoPartnerWsRequest));
        }
    }
}
