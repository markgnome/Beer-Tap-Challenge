using System.Collections.Generic;
using BeerTapHypermedia.ApiServices;
using BeerTapHypermedia.Model;
using BeerTapHypermedia.Model.DataContracts;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapHypermedia.WebApi.Hypermedia
{
    public class PintBeerSpec : SingleStateResourceSpec<Pint, int>
    {

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Kegs({id})/PintBeer");

        public override string EntrypointRelation => LinkRelations.Keg.PintBeer;

        public override IResourceStateSpec<Pint, NullState, int> StateSpec
        {
            get
            {
                return
                  new SingleStateSpec<Pint, int>
                  {
                      Links =
                      {
                           CreateLinkTemplate(LinkRelations.Keg.PintBeer , Uri , r => r.Id),
                      },
                      Operations = new StateSpecOperationsSource<Pint, int>
                      {
                          InitialPost = ServiceOperations.Create,
                          Post = ServiceOperations.Update
                      },
                  };
            }
        }
    }
}