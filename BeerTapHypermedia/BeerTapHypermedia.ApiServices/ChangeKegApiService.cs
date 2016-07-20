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
    public class ChangeKegApiService : IUpdateAResourceAsync<ChangeKeg, int>
    {

        readonly IApiUserProvider<BeerTapHypermediaApiUser> _userProvider;
        private readonly IOfficeKegRepository _officeKegRepository;
        private readonly IKegRepository _kegApiService;
        public ChangeKegApiService(IApiUserProvider<BeerTapHypermediaApiUser> userProvider, IOfficeKegRepository officeKegRepository, IKegRepository kegApiService)
        {
            if (userProvider == null) throw new ArgumentNullException(nameof(userProvider));
            _userProvider = userProvider;
            _officeKegRepository = officeKegRepository;
            _kegApiService = kegApiService;
        }

        public Task<ChangeKeg> UpdateAsync(ChangeKeg resource, IRequestContext context, CancellationToken cancellation)
        {
            var messageNoResource = $"Keg resource with id {resource.Id} cannot be found";
            try
            {
                var searchKeg = _kegApiService.Get(resource.Id);
                if (searchKeg == null) throw context.CreateNotFoundHttpResponseException<ChangeKeg>();
                _officeKegRepository.Change(resource.Id, (int) resource.Brand);
            }
            catch
                (Exception)
            {
                throw context.CreateHttpResponseException<ChangeKeg>(messageNoResource, HttpStatusCode.BadRequest);
            }
            return Task.FromResult(resource);
        }
    }
}
