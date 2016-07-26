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
    public class ChangeKegApiService : ICreateAResourceAsync<ChangeKeg, int>
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

        public Task<ResourceCreationResult<ChangeKeg, int>> CreateAsync(ChangeKeg resource, IRequestContext context, CancellationToken cancellation)
        {
            try
            {
                resource.KegId =
                    context.UriParameters.GetByName<int>("kegId")
                        .EnsureValue(() => new ArgumentNullException(nameof(resource)));
                var searchKeg = _kegApiService.Get(resource.Id);
                if (searchKeg == null) throw new ArgumentNullException(nameof(resource));
                _officeKegRepository.Change(resource.Id, (int)resource.Brand);
                resource.OfficeId = searchKeg.OfficeId;
            }
            catch (ArgumentNullException argumentNullException)
            {
                throw context.CreateHttpResponseException<Pint>(
                    $"Keg resource with id {resource.Id} cannot be found. {argumentNullException.Message}",
                    HttpStatusCode.BadRequest);
            }
            catch
                (Exception exception)
            {
                throw context.CreateHttpResponseException<ChangeKeg>(exception.Message, HttpStatusCode.BadRequest);
            }
            return Task.FromResult(new ResourceCreationResult<ChangeKeg, int>(resource));
        }
    }
}
