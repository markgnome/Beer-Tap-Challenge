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

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({officeId})/Kegs({kegId})/Replace");

        public override string EntrypointRelation => LinkRelations.Keg.ReplaceKeg;

        protected override IEnumerable<ResourceLinkTemplate<ReplaceKeg>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri.Many, c => c.OfficeId, c => c.KegId);
        }

        public override IResourceStateSpec<ReplaceKeg, NullState, int> StateSpec => new SingleStateSpec<ReplaceKeg, int>
        {
            Links =
            {
                CreateLinkTemplate(LinkRelations.Keg.ReplaceKeg , Uri, c => c.OfficeId, c => c.KegId),
            },
            Operations = new StateSpecOperationsSource<ReplaceKeg, int>
            {
                InitialPost = ServiceOperations.Create
            },
        };
    }
}