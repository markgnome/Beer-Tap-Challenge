using System.Collections.Generic;
using BeerTapHypermedia.DataAccess.Entities;

namespace BeerTapHypermedia.DataAccess
{
    public interface IOfficeRepository
    {
        Office Get(int officeId);
        IEnumerable<Office> GetAll();
        int Save(Office office);
        void Update(Office office);
        void Delete(int officeId);

    }
}
