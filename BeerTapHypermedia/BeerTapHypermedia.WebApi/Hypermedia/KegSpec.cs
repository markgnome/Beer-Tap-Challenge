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
                    CreateLinkTemplate(LinkRelations.Keg, ReplaceKegSpec.Uri.Many, c => c.KegId)
                },
                Operations = new StateSpecOperationsSource<KegModel, int>()
                {
                    Get = ServiceOperations.Get,
                    InitialPost = ServiceOperations.Create

                }
            };
            yield return new ResourceStateSpec<KegModel, KegState, int> (KegState.Nearly)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.Keg, ReplaceKegSpec.Uri.Many, c => c.KegId)
                },
                Operations = new StateSpecOperationsSource<KegModel, int>()
                {
                    Get = ServiceOperations.Get,
                    InitialPost = ServiceOperations.Create

                }
            };
            yield return new ResourceStateSpec<KegModel, KegState, int>(KegState.Full)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.Kegs.ChangeKeg, ChangeKegSpec.Uri.Many, c => c.KegId),
                    CreateLinkTemplate(LinkRelations.Keg, PintBeerSpec.Uri.Many, c => c.KegId)
                },
                Operations = new StateSpecOperationsSource<KegModel, int>()
                {
                    Get = ServiceOperations.Get,
                    Put = ServiceOperations.Update,
                    InitialPost = ServiceOperations.Create
                }
            };
            yield return new ResourceStateSpec<KegModel, KegState, int>(KegState.Reduced)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.Kegs.ChangeKeg, ChangeKegSpec.Uri.Many, c => c.KegId),
                     CreateLinkTemplate(LinkRelations.Keg, PintBeerSpec.Uri.Many, c => c.KegId)
                },
                Operations = new StateSpecOperationsSource<KegModel, int>()
                {
                    Get = ServiceOperations.Get,
                    Put = ServiceOperations.Update,
                    InitialPost = ServiceOperations.Create
                }
            };
        }

    }
}