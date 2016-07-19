using System.Collections.Generic;
using BeerTapHypermedia.ApiServices;
using BeerTapHypermedia.Model;
using BeerTapHypermedia.Model.DataContracts;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapHypermedia.WebApi.Hypermedia
{
    public class ReplaceKegSpec : SingleStateResourceSpec<ReplaceKeg, int>
    {

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Keg({id})/Replace");

        public override string EntrypointRelation => LinkRelations.Kegs.ReplaceKeg;

        public override IResourceStateSpec<ReplaceKeg, NullState, int> StateSpec
        {
            get
            {
                return
                  new SingleStateSpec<ReplaceKeg, int>
                  {
                      Links =
                      {
                           CreateLinkTemplate(LinkRelations.Kegs.ReplaceKeg , Uri , r => r.KegId),
                      },
                      Operations = new StateSpecOperationsSource<ReplaceKeg, int>
                      {
                          InitialPost = ServiceOperations.Create
                      },
                  };
            }
        }
    }
}