using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public IEnumerable<LocationDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save(LocationDto location)
        {
            throw new NotImplementedException();
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
