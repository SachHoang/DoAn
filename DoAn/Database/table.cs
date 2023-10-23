namespace DoAn.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class table
    {
        [Key]
        public int tid { get; set; }

        [StringLength(15)]
        public string tname { get; set; }
    }
}
