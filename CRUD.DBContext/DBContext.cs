using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CRUD.DBContext
{
    using Model.Model;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Contact> Contact { get; set; }
        public DbSet<Phone> Phone { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Phone>()
                .HasRequired<Contact>(s => s.Contact)
                .WithMany(g => g.Phones)
                .HasForeignKey<Guid>(s => s.IdContact);
            base.OnModelCreating(modelBuilder);
        }
    }
}
