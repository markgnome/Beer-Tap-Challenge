using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTapHypermedia.DataAccess.Dtos;

namespace BeerTapHypermedia.DataAccess
{
    public interface ILocationRepository
    {
        LocationDto Get(int locationId);
        IEnumerable<LocationDto> GetAll();
        int Save(LocationDto location);
        void Update(LocationDto location);
        void Delete(int locationId);

    }
}
