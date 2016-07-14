using BeerTapHypermedia.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapHypermedia.WebApi.Hypermedia
{
    public class OfficeSpec : SingleStateResourceSpec<Office, int>
    {

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Office({id})");

        public override string EntrypointRelation => LinkRelations.Office;

        public override IResourceStateSpec<Office, NullState, int> StateSpec
        {
            get
            {
                return
                  new SingleStateSpec<Office, int>
                  {
                      Links =
                      {
                           CreateLinkTemplate(LinkRelations.Office , OfficeSpec.Uri , r => r.OfficeId),
                      },
                      Operations = new StateSpecOperationsSource<Office, int>
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