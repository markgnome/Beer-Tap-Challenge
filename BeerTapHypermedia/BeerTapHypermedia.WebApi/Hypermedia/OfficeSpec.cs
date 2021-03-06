﻿using System.Collections.Generic;
using BeerTapHypermedia.ApiServices;
using BeerTapHypermedia.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapHypermedia.WebApi.Hypermedia
{
    public class OfficeSpec : SingleStateResourceSpec<OfficeModel, int>
    {

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({id})");
        public static ResourceUriTemplate UriOfficeAndKegs = ResourceUriTemplate.Create("Offices({officeId})/Kegs");
        public override string EntrypointRelation => LinkRelations.Offices;
        protected override IEnumerable<ResourceLinkTemplate<OfficeModel>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.OfficeId);
        }
        public override IResourceStateSpec<OfficeModel, NullState, int> StateSpec
        {
            get
            {
                return
                  new SingleStateSpec<OfficeModel, int>
                  {
                      Links =
                      {
                           CreateLinkTemplate(LinkRelations.Keg.Kurl, UriOfficeAndKegs, r => r.OfficeId)
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