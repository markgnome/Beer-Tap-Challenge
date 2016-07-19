using System.Collections.Generic;
using BeerTapHypermedia.DataAccess.Entities;

namespace BeerTapHypermedia.DataAccess
{
    public interface IOfficeKegRepository
    {
        void Change(int kegId, int brandId);
        Keg Replace(int officeId, int brandId);
        void Pint(int kegId, decimal glassMl);
    }
}
