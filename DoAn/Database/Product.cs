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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [Required]
        [StringLength(255)]
        public string pName { get; set; }

        public int Price { get; set; }

        public int? catID { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        public virtual category category { get; set; }
    }
}
