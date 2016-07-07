using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.Services.Security;

namespace BeerTapHypermedia.ApiServices.Security
{

    public class BeerTapHypermediaApiUser : ApiUser<UserAuthData>
    {
        public BeerTapHypermediaApiUser(string name, Option<UserAuthData> authData)
            : base(authData)
        {
            Name = name;
        }

        public string Name { get; private set; }

    }

    public class BeerTapHypermediaUserFactory : ApiUserFactory<BeerTapHypermediaApiUser, UserAuthData>
    {
        public BeerTapHypermediaUserFactory() :
            base(new HttpRequestDataStore<UserAuthData>())
        {
        }

        protected override BeerTapHypermediaApiUser CreateUser(Option<UserAuthData> auth)
        {
            return new BeerTapHypermediaApiUser("BeerTapHypermedia user", auth);
        }
    }

}
