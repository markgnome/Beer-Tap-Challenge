using BeerTapHypermedia.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTapHypermedia.ApiServices
{
    public interface IOfficeApiService :
        IGetAResourceAsync<OfficeModel, int>,
        IGetManyOfAResourceAsync<OfficeModel, int>,
        ICreateAResourceAsync<OfficeModel, int>,
        IUpdateAResourceAsync<OfficeModel, int>,
        IDeleteResourceAsync<OfficeModel, int>
    {
    }
}
