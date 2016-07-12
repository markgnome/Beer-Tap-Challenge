using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                return context.Database.SqlQuery<LocationDto>("SELECT * FROM LOCATIONS").FirstOrDefault();
            }
        }

        public IEnumerable<LocationDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Save(LocationDto location)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var cityParam = new SqlParameter()
                {
                    ParameterName = "@City",
                    SqlDbType = SqlDbType.VarChar,
                    Value = location.City
                };
                var countryParam = new SqlParameter()
                {
                    ParameterName = "@Country",
                    SqlDbType = SqlDbType.VarChar,
                    Value = location.Country
                };
                var resultParam = new SqlParameter()
                {
                    ParameterName = "@Result",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };


                var data = context.Database.SqlQuery<int>("[dbo].[Location_Add] @City, @Country, @Result OUT", cityParam,
                    countryParam, resultParam);

                return Convert.ToInt32(resultParam.Value);
            }
        }

        public void Update(LocationDto location)
        {
            throw new NotImplementedException();
        }

        public void Delete(int locationId)
        {
            throw new NotImplementedException();
        }
    }

}
