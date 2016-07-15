using BeerTapHypermedia.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTapHypermedia.ApiServices
{
    public interface IOfficeApiService :
        IGetAResourceAsync<Office, int>,
        IGetManyOfAResourceAsync<Office, int>,
        ICreateAResourceAsync<Office, int>,
        IUpdateAResourceAsync<Office, int>,
        IDeleteResourceAsync<Office, int>
    {
    }
}
