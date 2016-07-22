using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using IQ.Platform.Framework.WebApi.Services.Security;
using BeerTapHypermedia.ApiServices.Security;
using BeerTapHypermedia.DataAccess;
using BeerTapHypermedia.Model;
using BeerTapHypermedia.Model.Enums;
using IQ.Platform.Framework.WebApi;
using AutoMapper;
using BeerTapHypermedia.DataAccess.Entities;
using BeerTapHypermedia.Model.DataContracts;
using IQ.Platform.Framework.Common;

namespace BeerTapHypermedia.ApiServices
{
    public class OfficeKegApiService : IGetAResourceAsync<OfficeKegModel, int>
    {

        readonly IApiUserProvider<BeerTapHypermediaApiUser> _userProvider;
        private readonly IOfficeRepository _officeRepository;
        private readonly IKegRepository _kegRepository;
        public OfficeKegApiService(IApiUserProvider<BeerTapHypermediaApiUser> userProvider, IKegRepository kegRepository, IOfficeRepository officeRepository)
        {
            if (userProvider == null) throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;
            _kegRepository = kegRepository;
            _officeRepository = officeRepository;
        }

        public Task<OfficeKegModel> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
