namespace DoAn.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMain")]
    public partial class tblMain
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMain()
        {
            tblDetails = new HashSet<tblDetail>();
        }

        [Key]
        public int MainID { get; set; }

        [Required]
        [StringLength(50)]
        public string TableName { get; set; }

        public double total { get; set; }

        [Column(TypeName = "date")]
        public DateTime? aDate { get; set; }

        [StringLength(15)]
        public string aTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDetail> tblDetails { get; set; }
    }
}
