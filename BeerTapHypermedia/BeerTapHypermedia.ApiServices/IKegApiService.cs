using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BeerTapHypermedia.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTapHypermedia.ApiServices
{
    public interface IKegApiService :
        IGetAResourceAsync<KegModel, int>,
        IGetManyOfAResourceAsync<KegModel, int>,
        ICreateAResourceAsync<KegModel, int>,
        IUpdateAResourceAsync<KegModel, int>,
        IDeleteResourceAsync<KegModel, int>
    {
        //Task<IEnumerable<KegModel>> GetManyAsync(int resourceId, IRequestContext context, CancellationToken cancellation);
    }
}
