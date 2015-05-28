using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITServices.Framework.Data.Models
{
    [Table("ARData.CBPartnerPermission")]
    public class PartnerPermission
    {
        [Key]
        public int RowID { get; set; }

        [Column(TypeName = "varchar")]
        public string PartnerID { get; set; }

        public DateTime CreatedDT { get; set; }

        public DateTime ModifiedDT { get; set; }

        public string TeamTrackID { get; set; }

        public DateTime SysInsertedDT { get; set; }

        public DateTime SysModifiedDT { get; set; }

        [Column(TypeName = "varchar")]
        public string WebMethodDID { get; set; }

        public virtual Partner Partner { get; set; }
    }
}