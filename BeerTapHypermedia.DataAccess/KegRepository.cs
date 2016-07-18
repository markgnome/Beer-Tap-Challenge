using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using BeerTapHypermedia.DataAccess.Entities;
using Castle.Core;

namespace BeerTapHypermedia.DataAccess
{
    public class KegRepository : IKegRepository
    {
        private readonly IDatabaseContextFactory<BeerTapDbContext> _contextFactory;

        public KegRepository(IDatabaseContextFactory<BeerTapDbContext> contextFactory)
        {
            if (contextFactory == null) throw new ArgumentNullException(nameof(contextFactory));
            _contextFactory = contextFactory;
        }

        public Keg Get(int kegId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.Kegs.First(k => k.Id == kegId);
            }
        }

        public IEnumerable<Keg> GetAll(int? officeId = null)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return officeId != null ? context.Kegs.Where(k => k.OfficeId == officeId.Value).ToList() : context.Kegs.ToList();
            }
        }

        public int Save(Keg keg)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var id = context.Kegs.Add(keg).Id;
                context.SaveChanges();
                return id;
            }
        }

        public void Update(Keg keg)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var current = context.Kegs.First(k => k.Id == keg.Id);
                current.BrandId = keg.BrandId;
                current.Quantity = keg.Quantity;
                context.SaveChanges();
            }
        }

        public void Delete(int kegId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var remove = context.Kegs.First(k => k.Id == kegId);
                context.Kegs.Remove(remove);
                context.SaveChanges();
            }
        }
    }

}
