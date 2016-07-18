using System.Collections.Generic;
using BeerTapHypermedia.DataAccess.Entities;

namespace BeerTapHypermedia.DataAccess
{
    public interface IKegRepository
    {
        Keg Get(int kegId);
        IEnumerable<Keg> GetAll();
        int Save(Keg keg);
        void Update(Keg keg);
        void Delete(int kegId);

    }
}
