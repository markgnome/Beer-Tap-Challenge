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

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("PintBeer");

        public override string EntrypointRelation => LinkRelations.Keg.PintBeer;

        protected override IEnumerable<ResourceLinkTemplate<Pint>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri);
        }

        public override IResourceStateSpec<Pint, NullState, int> StateSpec => new SingleStateSpec<Pint, int>
        {
            Links =
            {
                CreateLinkTemplate(LinkRelations.Keg.PintBeer, Uri),
            },
            Operations = new StateSpecOperationsSource<Pint, int>
            {
                InitialPost = ServiceOperations.Create,
            },
        };
    }
}