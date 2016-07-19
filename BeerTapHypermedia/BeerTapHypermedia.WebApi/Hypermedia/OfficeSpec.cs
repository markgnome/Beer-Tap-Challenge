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

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Office({id})");

        public override string EntrypointRelation => LinkRelations.Office;

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