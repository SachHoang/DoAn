using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DoAn.Database
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<table> tables { get; set; }
        public virtual DbSet<tblDetail> tblDetails { get; set; }
        public virtual DbSet<tblMain> tblMains { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.tblDetails)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.proID);

            modelBuilder.Entity<tblMain>()
                .Property(e => e.aTime)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.upass)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.uName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.uPhone)
                .IsUnicode(false);
        }
    }
}
