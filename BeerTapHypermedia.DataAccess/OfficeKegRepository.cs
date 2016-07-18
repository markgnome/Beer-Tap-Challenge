﻿using System;
using System.Collections.Generic;
using System.Data;
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
            _kegRepository.Update(new Keg() { Id = kegId, BrandId = brandId, Quantity = 2000 });
        }

        public void Replace(int kegId)
        {
            var keg = _kegRepository.Get(kegId);
            keg.Quantity = 2000;
            _kegRepository.Update(keg);
        }

        public void Pint(int kegId, decimal glassMl)
        {
            var keg = _kegRepository.Get(kegId);
            keg.Quantity -= glassMl;
            _kegRepository.Update(keg);
        }
    }

}
