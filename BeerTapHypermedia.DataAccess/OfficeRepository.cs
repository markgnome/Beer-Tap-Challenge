using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using BeerTapHypermedia.DataAccess.Entities;
using Castle.Core;
using IQ.Framework.Patterns.Mapping;

namespace BeerTapHypermedia.DataAccess
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly IDatabaseContextFactory<BeerTapDbContext> _contextFactory;

        public OfficeRepository(IDatabaseContextFactory<BeerTapDbContext> contextFactory)
        {
            if (contextFactory == null) throw new ArgumentNullException(nameof(contextFactory));
            _contextFactory = contextFactory;
        }

        public Office Get(int officeId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.Offices.First(o => o.Id == officeId);
            }
        }

        public IEnumerable<Office> GetAll()
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.Offices.ToList();
            }
        }

        public int Save(Office office)
        {
            using (var context = _contextFactory.CreateContext())
            {
                context.Offices.Add(office);
                return context.SaveChanges();
            }
        }

        public void Update(Office office)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var current = context.Offices.First(o => o.Id == office.Id);
                current.Name = office.Name;
                current.Description = office.Description;
                current.LocationId = office.LocationId;
                context.SaveChanges();
            }
        }

        public void Delete(int officeId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var officeIdParam = new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = officeId };
                context.Database.ExecuteSqlCommand("DELETE FROM Offices WHERE Id = @Id", officeIdParam);
            }
        }
    }

}
