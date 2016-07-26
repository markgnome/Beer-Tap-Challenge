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

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({officeId})/Kegs({kegId})/Change");

        public override string EntrypointRelation => LinkRelations.Keg.ChangeKeg;

        protected override IEnumerable<ResourceLinkTemplate<ChangeKeg>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri.Many, c => c.OfficeId, c => c.KegId);
        }

        public override IResourceStateSpec<ChangeKeg, NullState, int> StateSpec => new SingleStateSpec<ChangeKeg, int>
        {
            Links =
            {
                CreateLinkTemplate(LinkRelations.Keg.ChangeKeg , Uri.Many, c => c.OfficeId, c => c.KegId),
            },
            Operations = new StateSpecOperationsSource<ChangeKeg, int>
            {
                InitialPost = ServiceOperations.Create
            },
        };
    }
}