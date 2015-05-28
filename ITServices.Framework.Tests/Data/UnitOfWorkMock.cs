
using System;
using ITServices.Framework.Data;
using ITServices.Framework.Data.Models;
using ITServices.Framework.Data.Repositories;
using ITServices.Framework.Tests.Data.Repositories;

namespace ITServices.Framework.Tests.Data
{
    public class UnitOfWorkMock : IUnitOfWork
    {
       // private ITServicesDataContext context = new ITServicesDataContext();
        private bool disposed;
       
        private IRepository<Partner> partnerRepository;
        private IRepository<PartnerIPAddress> partnerIPAddressRepository;
        private IRepository<WebService> webServiceRepository;
        private IRepository<WebMethod> webMethodRepository;

        public bool IsDisposed { get; private set; }

        public IRepository<Partner> PartnerRepository
        {
            get { return partnerRepository ?? (partnerRepository = new PartnerRepositoryMock()); }
        }

        public IRepository<PartnerIPAddress> PartnerIPAddressRepository
        {
            get
            {
                return partnerIPAddressRepository ?? (partnerIPAddressRepository = new PartnerIPAddressRepositoryMock());
            }
        }

        public IRepository<WebService> WebServiceRepository
        {
            get { return webServiceRepository ?? (webServiceRepository = new WebServiceRepositoryMock()); }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public IRepository<WebMethod> WebMethodRepository
        {
            get { return webMethodRepository ?? (webMethodRepository = new WebMethodRepositoryMock()); }
        }

        public void Dispose()
        {
            disposed = true;
            //throw new NotImplementedException();
        }
    }
}
