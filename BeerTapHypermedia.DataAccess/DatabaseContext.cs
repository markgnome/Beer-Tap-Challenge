using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.DataPersistenceFramework.DAL.EF;
using IQ.DataPersistenceFramework.Languages;

namespace BeerTapHypermedia.DataAccess
{
    public class BeerTapContext : DatabaseBaseContext, ILocalizedApplication
    {
        private const string ConnectionStringName = "name=DataConnection";

        public BeerTapContext() : base(ConnectionStringName)
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Configurations.Add(new CatalogProductOnOrderConfiguration());
        //    modelBuilder.Configurations.Add(new CatalogProductInStockConfiguration());

        //    base.OnModelCreating(modelBuilder);
        //}

        //public DbSet<CatalogProductOnOrderRecord> CatalogProductOnOrder { get; set; }
        //public DbSet<CatalogProductInStockRecord> CatalogProductInStock { get; set; }

        public DbSet<Language> Languages { get; set; }
        public DbSet<LocalizedStringIndex> LocalizedStringIndices { get; set; }
    }
}
