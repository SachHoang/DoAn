namespace DoAn.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        public int userID { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(10)]
        public string upass { get; set; }

        [Required]
        [StringLength(50)]
        public string uName { get; set; }

        [StringLength(20)]
        public string uPhone { get; set; }
    }
}
