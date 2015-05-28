using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Controllers;
using ITServices.Framework.DTO;

namespace ITServices.Framework.API.Filters
{
    public class Credentials
    {
        public DTOPartnerCredential Get(HttpActionContext actionContext)
        {
            IEnumerable<string> arAuthHeaders;
            if (!actionContext.Request.Headers.TryGetValues("Authorization", out arAuthHeaders))
            {
                throw new Exception("Request missing Authorization Headers");
            }
            string[] authorization = arAuthHeaders.First().Split(' ');
            string[] credentials = authorization[1].Split(':');

            DTOPartnerCredential dtoPartnerCredential = new DTOPartnerCredential();
            dtoPartnerCredential.PartnerID = credentials[0];
            dtoPartnerCredential.PartnerPwd = credentials[1];

            return dtoPartnerCredential;
        }
    }
}