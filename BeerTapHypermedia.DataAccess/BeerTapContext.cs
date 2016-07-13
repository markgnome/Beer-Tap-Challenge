using System.Data.Entity;
using IQ.DataPersistenceFramework.DAL.EF;
using IQ.DataPersistenceFramework.Languages;

namespace BeerTapHypermedia.DataAccess
{
    public class BeerTapContext : DatabaseBaseContext, ILocalizedApplication
    {
        public BeerTapContext(string connectionName) : base(connectionName)
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BeerTapContext>());
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
