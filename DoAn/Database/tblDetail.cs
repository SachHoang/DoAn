namespace DoAn.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblDetail
    {
        [Key]
        public int DetailID { get; set; }

        public int? MainID { get; set; }

        public int? proID { get; set; }

        public int? qty { get; set; }

        public double? Price { get; set; }

        public double? amount { get; set; }
    }
}
