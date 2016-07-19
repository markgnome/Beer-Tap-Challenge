using System.Threading;
using System.Threading.Tasks;
using BeerTapHypermedia.Model;
using BeerTapHypermedia.Model.DataContracts;
using IQ.Platform.Framework.WebApi;

namespace BeerTapHypermedia.ApiServices
{
    public interface IOfficeKegApiService

    {
        Task<KegModel> ReplaceKeg(ReplaceKeg resource, IRequestContext context, CancellationToken cancellation);
        Task<Beer> PullBeer(Pint resource, IRequestContext context, CancellationToken cancellation);
        Task<KegModel> ChangeKeg(ChangeKeg resource, IRequestContext context, CancellationToken cancellation);
    }
}
