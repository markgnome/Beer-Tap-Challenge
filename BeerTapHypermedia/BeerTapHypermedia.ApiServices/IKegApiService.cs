using BeerTapHypermedia.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTapHypermedia.ApiServices
{
    public interface IKegApiService :
        IGetAResourceAsync<Keg, int>,
        IGetManyOfAResourceAsync<Keg, int>,
        ICreateAResourceAsync<Keg, int>,
        IUpdateAResourceAsync<Keg, int>,
        IDeleteResourceAsync<Keg, int>
    {
    }
}
