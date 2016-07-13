using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BeerTapHypermedia.DataAccess;
using BeerTapHypermedia.DataAccess.Dtos;

namespace BeerTapHypermedia.IntegrationTests.MockRepositories
{
    public class LocationRepositoryMock 
    {
        private List<LocationDto> _locations;

        public LocationRepositoryMock()
        {
            _locations = new List<LocationDto>();
        }

        public LocationDto Get(int locationId)
        {
            var loc = Locations().First();
            loc.Id = locationId;
            return loc;
        }

        public IEnumerable<LocationDto> GetAll()
        {
            return Locations();
        }

        public int Save(LocationDto location)
        {
            var tempId = _locations.Count + 1;
            location.Id = tempId;
            _locations.Add(location);
            return tempId;
        }

        public void Update(LocationDto location)
        {
            var loc = _locations.First(l => l.Id == location.Id);
            if (loc != null)
            {
                loc.City = location.City;
                loc.Country = location.Country;
            }
        }

        public void Delete(int locationId)
        {
            var loc = _locations.First(l => l.Id == locationId);
            if (loc != null)
            {
                _locations.Remove(loc);
            }
        }

        private IEnumerable<LocationDto> Locations()
        {
            _locations = new List<LocationDto> { new LocationDto() { Id = 1, City = "Manila", Country = "PH" } };
            IEnumerable<LocationDto> results = _locations;
            return results;
        }
    }
}
