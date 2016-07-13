using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using BeerTapHypermedia.DataAccess.Dtos;
using Castle.Core;

namespace BeerTapHypermedia.DataAccess
{
    public class KegRepository : IKegRepository
    {
        private readonly IDatabaseContextFactory<BeerTapContext> _contextFactory;

        public KegRepository(IDatabaseContextFactory<BeerTapContext> contextFactory)
        {
            if (contextFactory == null) throw new ArgumentNullException(nameof(contextFactory));
            _contextFactory = contextFactory;
        }

        public KegDto Get(int kegId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var kegIdParam = new SqlParameter { ParameterName = "@KegId", SqlDbType = SqlDbType.Int, Value = kegId};
                return context.Database.SqlQuery<KegDto>("[dbo].[Keg_Select] @KegId", kegIdParam).FirstAsync().Result;
            }
        }

        public IEnumerable<KegDto> GetAll()
        {
            using (var context = _contextFactory.CreateContext())
            {
                var kegIdParam = new SqlParameter {ParameterName = "@KegId", SqlDbType = SqlDbType.Int, Value = 0};
                return context.Database.SqlQuery<KegDto>("[dbo].[Keg_Select] @KegId", kegIdParam).ToListAsync().Result;
            }
        }

        public int Save(KegDto keg)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var kegQuantity = new SqlParameter { ParameterName = "@Quantity", SqlDbType = SqlDbType.Decimal,  Value = keg.Quantity };
                var kegBrand = new SqlParameter { ParameterName = "@BrandId", SqlDbType = SqlDbType.Int, Value = keg.BrandId };
                var kegOffice = new SqlParameter { ParameterName = "@OfficeId", SqlDbType = SqlDbType.Int, Value = keg.OfficeId };
                var taskResult =
                    context.Database.SqlQuery<decimal>("[dbo].[Keg_Create] @Quantity, @Brand, @OfficedId", kegQuantity, kegBrand, kegOffice)
                        .FirstAsync()
                        .Result;
                return Convert.ToInt32(taskResult);
            }
        }

        public void Update(KegDto keg)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var kegQuantity = new SqlParameter { ParameterName = "@Quantity", SqlDbType = SqlDbType.Decimal, Value = keg.Quantity };
                var kegBrand = new SqlParameter { ParameterName = "@BrandId", SqlDbType = SqlDbType.Int, Value = keg.BrandId };
                var kegId = new SqlParameter { ParameterName = "@KegId", SqlDbType = SqlDbType.Int, Value = keg.Id };
                context.Database.ExecuteSqlCommand("[dbo].[Keg_Update] @Quantity, @BrandId, @Id", kegQuantity, kegBrand, kegId);
            }
        }

        public void Delete(int kegId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var kegIdParam = new SqlParameter { ParameterName = "@KegId", SqlDbType = SqlDbType.Int, Value = kegId };
                context.Database.ExecuteSqlCommand("DELETE FROM Kegs WHERE Id = @Id", kegIdParam);
            }
        }
    }

}
