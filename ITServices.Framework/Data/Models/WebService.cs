using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITServices.Framework.Data.Models
{
    [Table("ARData.CBLKWebService")]
    public class WebService
    {
        [Key]
        public int RowID { get; set; }

        [Column(TypeName = "varchar")]
        public string SystemName { get; set; }

        [Column(TypeName = "varchar")]
        public string WebServiceName { get; set; }

        public string DID { get; set; }

        public DateTime CreatedDT { get; set; }

        public DateTime ModifiedDT { get; set; }

        public DateTime SysModifiedDT { get; set; }

        public DateTime SysInsertedDT { get; set; }
    }
}