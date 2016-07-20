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
    public class ReplaceKegApiService : IUpdateAResourceAsync<ReplaceKeg, int>
    {

        readonly IApiUserProvider<BeerTapHypermediaApiUser> _userProvider;
        private readonly IOfficeKegRepository _officeKegRepository;
        private readonly IKegRepository _kegRepository;
        public ReplaceKegApiService(IApiUserProvider<BeerTapHypermediaApiUser> userProvider,
            IOfficeKegRepository officeKegRepository, IKegRepository kegRepository)
        {
            if (userProvider == null) throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;
            _officeKegRepository = officeKegRepository;
            _kegRepository = kegRepository;
        }

        public Task<ReplaceKeg> UpdateAsync(ReplaceKeg resource, IRequestContext context, CancellationToken cancellation)
        {
            var messageNoResource = $"Replace Keg resource with id {resource.Id} cannot be found";
            try
            {
                var searchKeg = _kegRepository.Get(resource.Id);
                if (searchKeg == null) throw context.CreateNotFoundHttpResponseException<ReplaceKeg>();
                _kegRepository.Delete(resource.KegId);
                var kegResult = _officeKegRepository.Replace(searchKeg.OfficeId, (int) resource.Brand);
                resource.KegId = kegResult.Id;
            }
            catch (Exception)
            {
                throw context.CreateHttpResponseException<Pint>(messageNoResource, HttpStatusCode.BadRequest);
            }
            return Task.FromResult(resource);
        }
    }
}
