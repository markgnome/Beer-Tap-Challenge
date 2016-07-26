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
    public class KegApiService : IKegApiService
    {

        readonly IApiUserProvider<BeerTapHypermediaApiUser> _userProvider;
        private readonly IKegRepository _kegRepository;
        public KegApiService(IApiUserProvider<BeerTapHypermediaApiUser> userProvider, IKegRepository kegRepository)
        {
            if (userProvider == null) throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;
            _kegRepository = kegRepository;
        }

        public Task<KegModel> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var kegDto = _kegRepository.Get(Convert.ToInt32(id));
            var keg = Mapper.Map<KegModel>(kegDto);
            return Task.FromResult(keg);
        }

        public Task<IEnumerable<KegModel>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context.UriParameters.GetByName<int>("officeId").EnsureValue(() => context.CreateHttpResponseException<OfficeModel>("The officeId must be supplied in the URI", HttpStatusCode.BadRequest));
            var kegId = context.UriParameters.GetByName<int>("kegId");
            var results = Mapper.Map<IEnumerable<KegModel>>(_kegRepository.GetAll(officeId));
            return Task.FromResult(kegId.HasValue ? results.Where(r => r.KegId == kegId.Value) : results);
        }

        public Task<IEnumerable<KegModel>> GetManyAsync(int resourceId, IRequestContext context, CancellationToken cancellation)
        {
            var kegsDto = _kegRepository.GetAll(resourceId);
            return Task.FromResult(Mapper.Map<IEnumerable<KegModel>>(kegsDto));
        }

        public Task<ResourceCreationResult<KegModel, int>> CreateAsync(KegModel resource, IRequestContext context, CancellationToken cancellation)
        {
            KegModel keg;
            try
            {
                resource.OfficeId =
                    context.UriParameters.GetByName<int>("officeId")
                        .EnsureValue(() => new ArgumentNullException(nameof(resource)));
                resource.Quantity = resource.Quantity == 0 ? KegModel.FullQuantity : resource.Quantity;
                var entity = Mapper.Map<Keg>(resource);
                var resultId = _kegRepository.Save(entity);
                var newKegDto = _kegRepository.Get(resultId);
                keg = Mapper.Map<KegModel>(newKegDto);
            }
            catch (ArgumentNullException argumentNullException)
            {
                throw context.CreateHttpResponseException<KegModel>($"Office resource with id {resource.Id} cannot be found. {argumentNullException.Message}",
                    HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {
                throw context.CreateHttpResponseException<KegModel>(exception.Message, HttpStatusCode.BadRequest);
            }
            return Task.FromResult(new ResourceCreationResult<KegModel, int>(keg));
        }

        public Task<KegModel> UpdateAsync(KegModel resource, IRequestContext context, CancellationToken cancellation)
        {
            var kegDto = Mapper.Map<Keg>(resource);
            _kegRepository.Update(kegDto);
            return Task.FromResult(resource);
        }

        public Task DeleteAsync(ResourceOrIdentifier<KegModel, int> input, IRequestContext context, CancellationToken cancellation)
        {
            if (input.HasResource)
            {
                _kegRepository.Delete(input.Id);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
