

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using ITServices.Framework.Data.Models;
using ITServices.Framework.Data.Repositories;

namespace ITServices.Framework.Tests.Data.Repositories
{
    public class WebServiceRepositoryMock : IRepository<WebService>
    {
        public IEnumerable<WebService> Get(Expression<Func<WebService, bool>> filter = null, Func<IQueryable<WebService>, IOrderedQueryable<WebService>> orderBy = null, int topCount = 500)
        {
            var webservices = new List<WebService>
            {
            new WebService
                {
                    DID = "1234",
                    SystemName = "ITServices",
                    WebServiceName = "Accounts"
                }
            };

            return webservices;
        }

        public WebService GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(WebService entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(WebService entityToDelete)
        {
            throw new NotImplementedException();
        }

        public void Update(WebService entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
