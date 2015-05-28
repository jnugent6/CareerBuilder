

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ITServices.Framework.Data.Models;
using ITServices.Framework.Data.Repositories;

namespace ITServices.Framework.Tests.Data.Repositories
{
    public class WebMethodRepositoryMock : IRepository<WebMethod>
    {
        public IEnumerable<WebMethod> Get(Expression<Func<WebMethod, bool>> filter = null, Func<IQueryable<WebMethod>, IOrderedQueryable<WebMethod>> orderBy = null, int topCount = 500)
        {
            var webmethods = new List<WebMethod>
            {
            new WebMethod
                {
                   DID = "5678",
                   WebServiceDID = "1234",
                   WebMethodName = "Get"
                }
            };

            return webmethods;
        }

        public WebMethod GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(WebMethod entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(WebMethod entityToDelete)
        {
            throw new NotImplementedException();
        }

        public void Update(WebMethod entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
