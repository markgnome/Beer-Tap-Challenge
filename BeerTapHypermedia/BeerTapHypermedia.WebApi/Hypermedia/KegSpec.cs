using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerTapHypermedia.Model;
using BeerTapHypermedia.Model.Enums;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapHypermedia.WebApi.Hypermedia
{
    public class KegSpec : ResourceSpec<KegModel, KegState, int>// , IStatefulKeg
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Keg({id})");
        public static ResourceUriTemplate UriOfficeAndKeg = ResourceUriTemplate.Create("Keg/Office({officeId})");
        public static ResourceUriTemplate KegUriReplaceKeg = ResourceUriTemplate.Create("Keg({id})/Replace");
        public static ResourceUriTemplate KegUriChangeKeg = ResourceUriTemplate.Create("Keg({id})/Change");
        public static ResourceUriTemplate KegUriPintKeg = ResourceUriTemplate.Create("Keg({id})/Pint");
        public override string EntrypointRelation => LinkRelations.Keg;

        protected override IEnumerable<ResourceLinkTemplate<KegModel>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, UriOfficeAndKeg, c => c.OfficeId);
        }

        protected override IEnumerable<IResourceStateSpec<KegModel, KegState, int>> GetStateSpecs()
        { 

            yield return new ResourceStateSpec<KegModel, KegState, int>(KegState.Empty)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.Keg, KegUriReplaceKeg.Many, c => c.KegId)
                },
                Operations = new StateSpecOperationsSource<KegModel, int>()
                {
                    Get = ServiceOperations.Get,
                    InitialPost = ServiceOperations.Create,
                    Post = ServiceOperations.Update,
                    Put = ServiceOperations.Update,
                    Delete = ServiceOperations.Delete,
                }
            };
            yield return new ResourceStateSpec<KegModel, KegState, int> (KegState.Nearly)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.Keg, KegUriReplaceKeg.Many, c => c.KegId)
                },
                Operations = new StateSpecOperationsSource<KegModel, int>()
                {
                    Get = ServiceOperations.Get,
                    InitialPost = ServiceOperations.Create,
                    Post = ServiceOperations.Update,
                    Put = ServiceOperations.Update,
                    Delete = ServiceOperations.Delete,
                }
            };
            yield return new ResourceStateSpec<KegModel, KegState, int>(KegState.Full)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.Kegs.ChangeKeg, KegUriChangeKeg.Many, c => c.KegId),
                    CreateLinkTemplate(LinkRelations.Keg, KegUriPintKeg.Many, c => c.KegId)
                },
                Operations = new StateSpecOperationsSource<KegModel, int>()
                {
                    Get = ServiceOperations.Get,
                    InitialPost = ServiceOperations.Create,
                    Post = ServiceOperations.Update,
                    Put = ServiceOperations.Update,
                    Delete = ServiceOperations.Delete,
                }
            };
            yield return new ResourceStateSpec<KegModel, KegState, int>(KegState.Reduced)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.Kegs.ChangeKeg, KegUriChangeKeg.Many, c => c.KegId),
                     CreateLinkTemplate(LinkRelations.Keg, KegUriPintKeg.Many, c => c.KegId)
                },
                Operations = new StateSpecOperationsSource<KegModel, int>()
                {
                    Get = ServiceOperations.Get,
                    InitialPost = ServiceOperations.Create,
                    Post = ServiceOperations.Update,
                    Put = ServiceOperations.Update,
                    Delete = ServiceOperations.Delete,
                }
            };
        }

        //public KegState KegState { get; set;  }
    }
}