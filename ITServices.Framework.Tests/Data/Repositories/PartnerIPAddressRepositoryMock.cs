

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ITServices.Framework.Data.Models;
using ITServices.Framework.Data.Repositories;

namespace ITServices.Framework.Tests.Data.Repositories
{
    public class PartnerIPAddressRepositoryMock : IRepository<PartnerIPAddress>
    {
        public IEnumerable<PartnerIPAddress> Get(Expression<Func<PartnerIPAddress, bool>> filter = null, Func<IQueryable<PartnerIPAddress>, IOrderedQueryable<PartnerIPAddress>> orderBy = null, int topCount = 500)
        {
            throw new NotImplementedException();
        }

        public PartnerIPAddress GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(PartnerIPAddress entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(PartnerIPAddress entityToDelete)
        {
            throw new NotImplementedException();
        }

        public void Update(PartnerIPAddress entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
