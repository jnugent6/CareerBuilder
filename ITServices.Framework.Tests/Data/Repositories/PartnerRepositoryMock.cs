

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using ITServices.Framework.Data.Models;
using ITServices.Framework.Data.Repositories;

namespace ITServices.Framework.Tests.Data.Repositories
{
    public class PartnerRepositoryMock : IRepository<Partner>
    {
        public IEnumerable<Partner> Get(Expression<Func<Partner, bool>> filter = null, Func<IQueryable<Partner>, IOrderedQueryable<Partner>> orderBy = null, int topCount = 500)
        {
           
            var partners = new List<Partner>
            {
            new Partner
                {
                    PartnerID = "AxiomCloud",
                    PartnerPassword = "Test123",
                    EnforceIPRestriction = true,
                    PartnerIPAddresses = new Collection<PartnerIPAddress>{new PartnerIPAddress {IPAddress = "127.0.0.1"}},
                    PartnerPermissions = new Collection<PartnerPermission>{new PartnerPermission{WebMethodDID = "5678"}}
                }
            };

            return partners;
        }

        public Partner GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Partner entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Partner entityToDelete)
        {
            throw new NotImplementedException();
        }

        public void Update(Partner entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
