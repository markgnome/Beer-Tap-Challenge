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
    public class DatabaseContext : DatabaseBaseContext, ILocalizedApplication
    {
        public DatabaseContext() : base() { }
        public DatabaseContext(string connectionName) : base(connectionName) { }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LocalizedStringIndex> LocalizedStringIndices { get; set; }
    }
}
