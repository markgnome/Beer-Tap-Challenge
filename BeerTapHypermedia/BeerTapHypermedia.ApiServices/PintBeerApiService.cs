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
    public class PintBeerApiService : ICreateAResourceAsync<Pint, int>
    {

        readonly IApiUserProvider<BeerTapHypermediaApiUser> _userProvider;
        private readonly IOfficeKegRepository _officeKegRepository;
        private readonly IKegRepository _kegRepository;
        public PintBeerApiService(IApiUserProvider<BeerTapHypermediaApiUser> userProvider, IOfficeKegRepository officeKegRepository, IKegRepository kegRepository)
        {
            if (userProvider == null) throw new ArgumentNullException(nameof(userProvider));
            _userProvider = userProvider;
            _officeKegRepository = officeKegRepository;
            _kegRepository = kegRepository;
        }


        public Task<ResourceCreationResult<Pint, int>> CreateAsync(Pint resource, IRequestContext context, CancellationToken cancellation)
        {
            try
            {
                resource.KegId =
                    context.UriParameters.GetByName<int>("kegId")
                        .EnsureValue(() => new ArgumentNullException(nameof(resource)));
                var searchKeg = _kegRepository.Get(resource.Id);

                if (searchKeg == null) throw new ArgumentNullException(nameof(resource));
                if (resource.Volume > searchKeg.Quantity) throw new ArgumentException(nameof(resource));

                _officeKegRepository.Pint(resource.Id, resource.Volume);
                resource.OfficeId = searchKeg.OfficeId;
            }
            catch (ArgumentNullException argumentNullException)
            {
                throw context.CreateHttpResponseException<Pint>(
                    $"Pint Keg resource with id {resource.Id} cannot be found. {argumentNullException.Message}",
                    HttpStatusCode.BadRequest);
            }
            catch
                (ArgumentException argumentException)
            {
                throw context.CreateHttpResponseException<Pint>(
                    $"Keg resource with id ({resource.KegId}) has no enough beer. Please replace the keg. {argumentException.Message}",
                    HttpStatusCode.BadRequest);

            }
            return Task.FromResult(new ResourceCreationResult<Pint, int>(resource));
        }
    }
}
