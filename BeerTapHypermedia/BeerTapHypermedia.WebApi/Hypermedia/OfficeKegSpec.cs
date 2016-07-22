using System.Collections.Generic;
using BeerTapHypermedia.ApiServices;
using BeerTapHypermedia.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapHypermedia.WebApi.Hypermedia
{
    public class OfficeKegSpec : SingleStateResourceSpec<OfficeKegModel, int>
    {
        public static ResourceUriTemplate UriOfficeAndKegs = ResourceUriTemplate.Create("Offices({officeId})/Kegs");
        public override string EntrypointRelation => LinkRelations.OfficeKegs;
        protected override IEnumerable<ResourceLinkTemplate<OfficeKegModel>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, UriOfficeAndKegs, c => c.OfficeId);
        }
        public override IResourceStateSpec<OfficeKegModel, NullState, int> StateSpec
        {
            get
            {
                return
                  new SingleStateSpec<OfficeKegModel, int>
                  {
                      Links =
                      {
                           CreateLinkTemplate(LinkRelations.OfficeKegs, UriOfficeAndKegs, r => r.OfficeId)

                      },
                      Operations = new StateSpecOperationsSource<OfficeKegModel, int>
                      {
                          Get = ServiceOperations.Get,
                          InitialPost = ServiceOperations.Create,
                          Post = ServiceOperations.Update,
                          Delete = ServiceOperations.Delete,
                      },
                  };
            }
        }
    }
}