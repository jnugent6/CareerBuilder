using System;
using ITServices.Framework.Data.Models;
using ITServices.Framework.Data.Repositories;

namespace ITServices.Framework.Data
{
    public interface IUnitOfWork : IDisposable
    {
        bool IsDisposed { get; }

        IRepository<Partner> PartnerRepository { get; }

        IRepository<PartnerIPAddress> PartnerIPAddressRepository { get; }

        IRepository<WebMethod> WebMethodRepository { get; }

        IRepository<WebService> WebServiceRepository { get; }

        void Save();
    }
}