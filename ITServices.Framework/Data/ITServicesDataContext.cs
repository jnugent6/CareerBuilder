namespace ITServices.Framework.Data
{
    using System.Data.Entity;
    using Models;

    public class ITServicesDataContext : DbContext
    {
        public ITServicesDataContext()
            : base("name=ITServicesDataContext")
        {
            Database.SetInitializer<ITServicesDataContext>(null);
        }

        //public ITServicesDataContext(string connString)
        //    : base(connString)
        //{
        //    Database.SetInitializer<ITServicesDataContext>(null);
        //}

        public virtual DbSet<WebMethod> WebMethods { get; set; }

        public virtual DbSet<WebService> WebServices { get; set; }

        public virtual DbSet<Partner> Partners { get; set; }

        public virtual DbSet<PartnerIPAddress> PartnerIPAddresses { get; set; }

        public virtual DbSet<PartnerPermission> PartnerPermissions { get; set; }
    }
}