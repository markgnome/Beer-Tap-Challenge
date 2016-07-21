using System.Collections.Generic;
using BeerTapHypermedia.ApiServices;
using BeerTapHypermedia.Model;
using BeerTapHypermedia.Model.DataContracts;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapHypermedia.WebApi.Hypermedia
{
    public class ChangeKegSpec : SingleStateResourceSpec<ChangeKeg, int>
    {

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Keg({id})/Change");

        public override string EntrypointRelation => LinkRelations.Keg.ChangeKeg;

        public override IResourceStateSpec<ChangeKeg, NullState, int> StateSpec
        {
            get
            {
                return
                  new SingleStateSpec<ChangeKeg, int>
                  {
                      Links =
                      {
                           CreateLinkTemplate(LinkRelations.Keg.ChangeKeg , Uri , r => r.KegId),
                      },
                      Operations = new StateSpecOperationsSource<ChangeKeg, int>
                      {
                          Post = ServiceOperations.Update
                      },
                  };
            }
        }
    }
}