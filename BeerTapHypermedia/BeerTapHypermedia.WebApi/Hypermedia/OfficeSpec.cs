using System.Collections.Generic;
using BeerTapHypermedia.ApiServices;
using BeerTapHypermedia.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapHypermedia.WebApi.Hypermedia
{
    public class OfficeSpec : SingleStateResourceSpec<OfficeModel, int>
    {

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Office({id})");

        public override string EntrypointRelation => LinkRelations.Office;

        //protected override IEnumerable<ResourceLinkTemplate<OfficeModel>> Links()
        //{
        //    yield return CreateLinkTemplate<LinksParametersSource>(CommonLinkRelations.Self, Uri, x => x.Parameters.OfficeId,
        //            x => x.Parameters.OfficeId, x => x.Resource.Id);
        //}


        public override IResourceStateSpec<OfficeModel, NullState, int> StateSpec
        {
            get
            {
                return
                  new SingleStateSpec<OfficeModel, int>
                  {
                      Links =
                      {
                           CreateLinkTemplate(LinkRelations.Office , Uri , r => r.OfficeId),
                      },
                      Operations = new StateSpecOperationsSource<OfficeModel, int>
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