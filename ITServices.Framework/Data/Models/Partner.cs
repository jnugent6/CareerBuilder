using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITServices.Framework.Data.Models
{
    using System.Collections.Generic;

    [Table("ARData.CBPartner")]
    public class Partner
    {
        public Partner()
        {
            PartnerIPAddresses = new HashSet<PartnerIPAddress>();
            PartnerPermissions = new HashSet<PartnerPermission>();
        }

        // public int RowID { get; set; }
        [Key]
        [Column(TypeName = "varchar")]
        public string PartnerID { get; set; }

        [Column(TypeName = "varchar")]
        public string PartnerPassword { get; set; }

        public string OrderObjectName { get; set; }

        public string AccountObjectName { get; set; }

        public string PurchaseBillingType { get; set; }

        public string PurchaseSalesRepID { get; set; }

        public string PurchaseAccountEmail { get; set; }

        [Column(TypeName = "bit")]
        public bool EnforceIPRestriction { get; set; }

        public virtual ICollection<PartnerIPAddress> PartnerIPAddresses { get; set; }

        public virtual ICollection<PartnerPermission> PartnerPermissions { get; set; }
    }
}