using System;
using System.Text;
using System.Collections.Generic;
using ITServices.Framework.Business;
using ITServices.Framework.Data;
using ITServices.Framework.DTO;
using ITServices.Framework.Tests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ITServices.Framework.Tests.Business
{
    /// <summary>
    /// Summary description for AuthenticationManagerTest
    /// </summary>
    [TestClass]
    public class AuthenticationManagerTest
    {
        [TestMethod]
        public void AuthenticateTest()
        {
            IUnitOfWork unitOfWork = new UnitOfWorkMock();
            IAuthenticationManager authenticationManager = new AuthenticationManager(unitOfWork);
            DTOPartnerCredential dtoPartnerCredential = new DTOPartnerCredential();
            dtoPartnerCredential.PartnerID = "AxiomCloud";
            dtoPartnerCredential.PartnerPwd = "Test123";
            Assert.IsTrue(authenticationManager.Authenticate(dtoPartnerCredential));
        }
    }
}
