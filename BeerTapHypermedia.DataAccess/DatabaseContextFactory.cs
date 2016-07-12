using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.LoggingEx;

namespace BeerTapHypermedia.DataAccess
{
    public class DatabaseContextFactory : IDbContextFactory<BeerTapContext>
    {
        private readonly ILog<BeerTapContext> _logger;
        public BeerTapContext Create()
        {
            var context = new BeerTapContext();
            context.Database.Log = s => _logger.Debug(s);
            return context;
        }

        public DatabaseContextFactory(ILog<BeerTapContext> logger)
        {
            if (logger == null) throw new ArgumentNullException(nameof(logger));
            _logger = logger;
        }
    }
}
