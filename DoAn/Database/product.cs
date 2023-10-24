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

    [Table("Product")]
    public partial class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [Required]
        [StringLength(255)]
        public string pName { get; set; }

        public int Price { get; set; }

        public int catID { get; set; }

        public virtual category category { get; set; }

    }
}
