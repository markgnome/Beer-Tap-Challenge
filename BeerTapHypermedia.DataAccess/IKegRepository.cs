using System.Collections.Generic;
using BeerTapHypermedia.DataAccess.Dtos;

namespace BeerTapHypermedia.DataAccess
{
    public interface IKegRepository
    {
        KegDto Get(int kegId);
        IEnumerable<KegDto> GetAll();
        int Save(KegDto keg);
        void Update(KegDto keg);
        void Delete(int kegId);

    }
}
