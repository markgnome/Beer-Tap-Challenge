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
    public class KegSpec : SingleStateResourceSpec<Keg, int>// , IStatefulKeg
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Keg({id})");

        public override string EntrypointRelation => LinkRelations.Keg;

        public override IResourceStateSpec<Keg, NullState, int> StateSpec
        {
            get
            {
                return
                  new SingleStateSpec<Keg, int>
                  {
                      Links =
                      {
                           CreateLinkTemplate(LinkRelations.Keg , OfficeSpec.Uri , r => r.KegId),
                      },
                      Operations = new StateSpecOperationsSource<Keg, int>
                      {
                          Get = ServiceOperations.Get,
                          InitialPost = ServiceOperations.Create,
                          Post = ServiceOperations.Update,
                          Delete = ServiceOperations.Delete,
                      },
                  };
            }
        }
        //protected override IEnumerable<IResourceStateSpec<Keg, KegState, int>> GetStateSpecs()
        //
        //    yield return new ResourceStateSpec<Keg, KegState, int>(KegState.Empty)
        //    {
        //        Links =
        //        {
        //            CreateLinkTemplate(LinkRelations.Kegs.ReplaceKeg, Uri.Many,  c => c.Id)
        //        },
        //        Operations = new StateSpecOperationsSource<Keg, int>()
        //        {
        //            Get = ServiceOperations.Get,
        //            InitialPost = ServiceOperations.Create,
        //            Post = ServiceOperations.Update,
        //            Put = ServiceOperations.Update,
        //            Delete = ServiceOperations.Delete,
        //        }
        //    };
        //    yield return new ResourceStateSpec<Keg, KegState, int> (KegState.Nearly)
        //    {
        //        Links =
        //        {
        //            CreateLinkTemplate(LinkRelations.Kegs.ReplaceKeg, Uri.Many,  c => c.Id)
        //        },
        //        Operations = new StateSpecOperationsSource<Keg, int>()
        //        {
        //            Get = ServiceOperations.Get,
        //            InitialPost = ServiceOperations.Create,
        //            Post = ServiceOperations.Update,
        //            Put = ServiceOperations.Update,
        //            Delete = ServiceOperations.Delete,
        //        }
        //    };
        //    yield return new ResourceStateSpec<Keg, KegState, int>(KegState.Full)
        //    {
        //        Links =
        //        {
        //            CreateLinkTemplate(LinkRelations.Kegs.ChangeKeg, Uri.Many, c => c.Id)
        //        },
        //        Operations = new StateSpecOperationsSource<Keg, int>()
        //        {
        //            Get = ServiceOperations.Get,
        //            InitialPost = ServiceOperations.Create,
        //            Post = ServiceOperations.Update,
        //            Put = ServiceOperations.Update,
        //            Delete = ServiceOperations.Delete,
        //        }
        //    };
        //    yield return new ResourceStateSpec<Keg, KegState, int>(KegState.Reduced)
        //    {
        //        Links =
        //        {
        //            CreateLinkTemplate(LinkRelations.Kegs.ChangeKeg, Uri.Many, c => c.KegId)
        //        },
        //        Operations = new StateSpecOperationsSource<Keg, int>()
        //        {
        //            Get = ServiceOperations.Get,
        //            InitialPost = ServiceOperations.Create,
        //            Post = ServiceOperations.Update,
        //            Put = ServiceOperations.Update,
        //            Delete = ServiceOperations.Delete,
        //        }
        //    };
        //}

        //public KegState KegState { get; set;  }
    }
}