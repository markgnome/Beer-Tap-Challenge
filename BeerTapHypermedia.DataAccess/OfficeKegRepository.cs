﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using Castle.Core;
using BeerTapHypermedia.DataAccess.Entities;

namespace BeerTapHypermedia.DataAccess
{
    public class OfficeKegRepository : IOfficeKegRepository
    {
        private readonly IDatabaseContextFactory<BeerTapDbContext> _contextFactory;
        private readonly IKegRepository _kegRepository;

        public OfficeKegRepository(IDatabaseContextFactory<BeerTapDbContext> contextFactory, IKegRepository kegRepository)
        {
            if (contextFactory == null) throw new ArgumentNullException(nameof(contextFactory));
            _contextFactory = contextFactory;
            _kegRepository = kegRepository;
        }

        public void Change(int kegId, int brandId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var keg = context.Kegs.Find(kegId);
                keg.BrandId = brandId;
                keg.Quantity = 2000;
                context.SaveChanges();
            }
        }

        public Keg Replace(int kegId, int brandId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var keg = context.Kegs.Find(kegId);
                keg.BrandId = brandId;
                keg.Quantity = 2000;
                context.SaveChanges();
                return keg;
            }
        }

        public void Pint(int kegId, decimal glassMl)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var keg = context.Kegs.First(k => k.Id == kegId);
                keg.Quantity -= glassMl;
                context.SaveChanges();
            }
        }
    }

}
