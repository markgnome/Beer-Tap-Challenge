using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
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
                return context.Offices.Find(officeId);
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
                context.SaveChanges();
                return office.Id;
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
                var office = context.Offices.Find(officeId);
                if (office != null)
                {
                    context.Offices.Remove(office);
                }
            }
        }
    }

}
