using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.LoggingEx;

namespace BeerTapHypermedia.DataAccess
{
    public class DatabaseContextFactory : IDatabaseContextFactory<BeerTapContext>
    {
        //private readonly ILog<BeerTapContext> _logger;
    
        //public DatabaseContextFactory(ILog<BeerTapContext> logger)
        //{
        //    if (logger == null) throw new ArgumentNullException(nameof(logger));
        //    _logger = logger;
        //}

        public BeerTapContext CreateContext()
        {
            var context = new BeerTapContext();
            //context.Database.Log = s => _logger.Debug(s);
            return context;
        }
    }
}
