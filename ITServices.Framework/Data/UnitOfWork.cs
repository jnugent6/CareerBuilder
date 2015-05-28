using System;
//using ITServices.Framework.Configurations;
using ITServices.Framework.Data.Models;
using ITServices.Framework.Data.Repositories;

namespace ITServices.Framework.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private ITServicesDataContext context = new ITServicesDataContext();
        private bool disposed;

        private IRepository<Partner> partnerRepository;
        private IRepository<PartnerIPAddress> partnerIPAddressRepository;
        private IRepository<WebService> webServiceRepository;
        private IRepository<WebMethod> webMethodRepository;
         public IRepository<Partner> PartnerRepository
        {
            get { return partnerRepository ?? (partnerRepository = new Repository<Partner>(context)); }
        }

        public IRepository<PartnerIPAddress> PartnerIPAddressRepository
        {
            get
            {
                return partnerIPAddressRepository ?? (partnerIPAddressRepository = new Repository<PartnerIPAddress>(context));
            }
        }

        public IRepository<WebService> WebServiceRepository
        {
            get { return webServiceRepository ?? (webServiceRepository = new Repository<WebService>(context)); }
        }

        public IRepository<WebMethod> WebMethodRepository
        {
            get { return webMethodRepository ?? (webMethodRepository = new Repository<WebMethod>(context)); }
        }

        public bool IsDisposed { get { return disposed; } }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}