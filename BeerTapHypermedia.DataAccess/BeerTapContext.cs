using System.Data.Entity;
using IQ.DataPersistenceFramework.DAL.EF;
using IQ.DataPersistenceFramework.Languages;

namespace BeerTapHypermedia.DataAccess
{
    public class BeerTapContext : DatabaseBaseContext, ILocalizedApplication
    {
        public BeerTapContext(string connectionName) : base(connectionName)
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<LocalizedStringIndex> LocalizedStringIndices { get; set; }
    }
}
