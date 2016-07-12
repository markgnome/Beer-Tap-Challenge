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
        Location Get(int locationId);
        IEnumerable<Location> GetAll();
        bool Save(Location location);
        void Update(Location location);
        void Delete(int locationId);

    }
}
