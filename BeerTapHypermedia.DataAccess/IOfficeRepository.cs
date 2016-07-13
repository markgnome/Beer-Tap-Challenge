using System.Collections.Generic;
using BeerTapHypermedia.DataAccess.Dtos;

namespace BeerTapHypermedia.DataAccess
{
    public interface IOfficeRepository
    {
        OfficeKegDto Get(int officeId);
        IEnumerable<OfficeKegDto> GetAll();
        int Save(OfficeDto office);
        void Update(OfficeDto office);
        void Delete(int officeId);

    }
}
