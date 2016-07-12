using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.LoggingEx;

namespace BeerTapHypermedia.DataAccess
{
    public class DatabaseContextFactory : IDbContextFactory<DatabaseContext>
    {
        private readonly ILog<DatabaseContext> _logger;
        public DatabaseContext Create()
        {
            var context = new DatabaseContext();
            context.Database.Log = s => _logger.Debug(s);
            return context;
        }

        public DatabaseContextFactory(ILog<DatabaseContext> logger)
        {
            if (logger == null) throw new ArgumentNullException(nameof(logger));
            _logger = logger;
        }
    }
}
