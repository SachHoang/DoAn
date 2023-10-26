namespace DoAn.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            tblDetails = new HashSet<tblDetail>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [Required]
        [StringLength(255)]
        public string pName { get; set; }

        public int Price { get; set; }

        public int catID { get; set; }

        [Column(TypeName = "image")]
        public byte[] pImage { get; set; }

        public virtual category category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDetail> tblDetails { get; set; }
    }
}
