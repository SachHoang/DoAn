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
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>()
                .Property(e => e.catName)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Address)
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
