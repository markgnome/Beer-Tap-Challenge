using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BeerTapHypermedia.DataAccess.Dtos;

namespace BeerTapHypermedia.DataAccess
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IDatabaseContextFactory<BeerTapContext> _contextFactory;

        public LocationRepository(IDatabaseContextFactory<BeerTapContext> contextFactory)
        {
            if (contextFactory == null) throw new ArgumentNullException(nameof(contextFactory));
            _contextFactory = contextFactory;
        }

        public LocationDto Get(int locationId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.Database.SqlQuery<LocationDto>("Select * From Locations Where Id = @Id", locationId).FirstOrDefault();
            }
        }

        public IEnumerable<LocationDto> GetAll()
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.Database.SqlQuery<LocationDto>("Select * From Locations").ToList();
            }
        }

        public int Save(LocationDto location)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var cityParam = new SqlParameter
                {
                    ParameterName = "@City",
                    SqlDbType = SqlDbType.VarChar,
                    Value = location.City
                };
                var countryParam = new SqlParameter
                {
                    ParameterName = "@Country",
                    SqlDbType = SqlDbType.VarChar,
                    Value = location.Country
                };
                var resultParam = new SqlParameter
                {
                    ParameterName = "@Result",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                context.Database.SqlQuery<int>("[dbo].[Location_Add] @City, @Country, @Result OUT", cityParam,
                    countryParam, resultParam);

                return Convert.ToInt32(resultParam.Value);
            }
        }

        public void Update(LocationDto location)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var cityParam = new SqlParameter
                {
                    ParameterName = "@City",
                    SqlDbType = SqlDbType.VarChar,
                    Value = location.City
                };
                var countryParam = new SqlParameter
                {
                    ParameterName = "@Country",
                    SqlDbType = SqlDbType.VarChar,
                    Value = location.Country
                };
                var idParam = new SqlParameter
                {
                    ParameterName = "@Id",
                    SqlDbType = SqlDbType.Int
                };

                context.Database.SqlQuery<int>("[dbo].[Location_Update] @Id, @City, @Country", idParam,
                    countryParam, countryParam);
            }
        }

        public void Delete(int locationId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM Locations WHERE Id = @Id", locationId);
            }
        }
    }

}
