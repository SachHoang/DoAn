namespace DoAn.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class product
    {
        [Key]
        public int pID { get; set; }

        [StringLength(50)]
        public string pName { get; set; }

        public double? pPrice { get; set; }

        public int? CategoryID { get; set; }

        [Column(TypeName = "image")]
        public byte[] pImage { get; set; }
    }
}
