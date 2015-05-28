using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITServices.Framework.Data.Models
{
    [Table("ARData.CBLKWebMethod")]
    public class WebMethod
    {
        public int RowID { get; set; }

        [Key]
        [Column(TypeName = "varchar")]
        public string DID { get; set; }

        [Column(TypeName = "varchar")]
        public string WebServiceDID { get; set; }

        [Column(TypeName = "varchar")]
        public string WebMethodName { get; set; }

        public DateTime CreatedDT { get; set; }

        public DateTime ModifiedDT { get; set; }

        public DateTime SysModifiedDT { get; set; }

        public DateTime SysInsertedDT { get; set; }
    }
}