using BeerTapHypermedia.DataAccess.Entities;
using IQ.DataPersistenceFramework.DAL.EF;

namespace BeerTapHypermedia.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BeerTapDbContext : DbContext
    {
        public BeerTapDbContext()
            : base("name=BeerTapDbContext")
        {
        }

        public virtual DbSet<Keg> Kegs { get; set; }
        public virtual DbSet<Office> Offices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<BeerTapDbContext>());

            modelBuilder.Entity<Office>().Property(e => e.Name).IsUnicode(false);

            modelBuilder.Entity<Office>().Property(e => e.Description).IsUnicode(false);

            modelBuilder.Entity<Office>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
