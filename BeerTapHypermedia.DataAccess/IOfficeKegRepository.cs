using System.Collections.Generic;
using BeerTapHypermedia.DataAccess.Dtos;

namespace BeerTapHypermedia.DataAccess
{
    public interface IOfficeKegRepository
    {
        void Change(int kegId, int brandId);
        void Replace(int kegId);
        void Pint(int kegId, decimal glassMl);
    }
}
