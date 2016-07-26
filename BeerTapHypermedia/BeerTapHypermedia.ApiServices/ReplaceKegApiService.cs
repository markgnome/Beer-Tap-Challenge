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
    public class ReplaceKegApiService : ICreateAResourceAsync<ReplaceKeg, int>
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

        public Task<ResourceCreationResult<ReplaceKeg, int>> CreateAsync(ReplaceKeg resource, IRequestContext context, CancellationToken cancellation)
        {
            try
            {
                resource.KegId =
                    context.UriParameters.GetByName<int>("kegId")
                        .EnsureValue(() => new ArgumentNullException(nameof(resource)));
                var searchKeg = _kegRepository.Get(resource.Id);
                if (searchKeg == null) throw new ArgumentNullException(nameof(resource));
                var kegResult = _officeKegRepository.Replace(resource.KegId, (int)resource.Brand);
                resource.KegId = kegResult.Id;
                resource.OfficeId = kegResult.OfficeId;
            }
            catch (ArgumentNullException argumentNullException)
            {
                throw context.CreateHttpResponseException<Pint>(
                    $"Keg resource with id {resource.Id} cannot be found. {argumentNullException.Message}",
                    HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {
                throw context.CreateHttpResponseException<ReplaceKeg>(exception.Message, HttpStatusCode.BadRequest);
            }
            return Task.FromResult(new ResourceCreationResult<ReplaceKeg, int>(resource));
        }
    }
}
