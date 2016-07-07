using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.AspNet.Handlers;
using IQ.Platform.Framework.WebApi.Services.Security;
using BeerTapHypermedia.ApiServices.Security;

namespace BeerTapHypermedia.WebApi.Handlers
{
    public class PutYourApiSafeNameUserContextProvidingHandler
            : ApiSecurityContextProvidingHandler<BeerTapHypermediaApiUser, NullUserContext>
    {

        public PutYourApiSafeNameUserContextProvidingHandler(
            IStoreDataInHttpRequest<BeerTapHypermediaApiUser> apiUserInRequestStore)
            : base(new BeerTapHypermediaUserFactory(), CreateContextProvider(), apiUserInRequestStore)
        {
        }

        static ApiUserContextProvider<BeerTapHypermediaApiUser, NullUserContext> CreateContextProvider()
        {
            return
                new ApiUserContextProvider<BeerTapHypermediaApiUser, NullUserContext>(_ => new NullUserContext());
        }
    }
}