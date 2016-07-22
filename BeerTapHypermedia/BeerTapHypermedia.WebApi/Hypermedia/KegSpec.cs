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
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({officeId})/Kegs({kegId})");
        

        public override string EntrypointRelation => LinkRelations.Offices;

        protected override IEnumerable<ResourceLinkTemplate<KegModel>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.OfficeId, c => c.KegId);
        }

        protected override IEnumerable<IResourceStateSpec<KegModel, KegState, int>> GetStateSpecs()
        { 

            yield return new ResourceStateSpec<KegModel, KegState, int>(KegState.Empty)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.Kegs, ReplaceKegSpec.Uri.Many)
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
                    CreateLinkTemplate(LinkRelations.Keg.ReplaceKeg, ReplaceKegSpec.Uri.Many),
                    CreateLinkTemplate(LinkRelations.Keg.PintBeer, PintBeerSpec.Uri.Many),
                    CreateLinkTemplate(LinkRelations.Keg.ChangeKeg, ChangeKegSpec.Uri.Many)
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
                    CreateLinkTemplate(LinkRelations.Keg.PintBeer, PintBeerSpec.Uri.Many),
                    CreateLinkTemplate(LinkRelations.Keg.ChangeKeg, ChangeKegSpec.Uri.Many)

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
                     CreateLinkTemplate(LinkRelations.Keg.PintBeer, PintBeerSpec.Uri.Many),
                     CreateLinkTemplate(LinkRelations.Keg.ChangeKeg, ChangeKegSpec.Uri.Many)
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