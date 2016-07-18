using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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

namespace BeerTapHypermedia.ApiServices
{
    public class KegApiService : IKegApiService
    {

        readonly IApiUserProvider<BeerTapHypermediaApiUser> _userProvider;
        private readonly IKegRepository _kegRepository;
        private readonly IOfficeKegRepository _officeKegRepository;
        public KegApiService(IApiUserProvider<BeerTapHypermediaApiUser> userProvider, IOfficeKegRepository officeKegRepository, IKegRepository kegRepository)
        {
            if (userProvider == null) throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;
            _officeKegRepository = officeKegRepository;
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
            var kegs = new List<KegModel>();
            var kegsDto = _kegRepository.GetAll();
            return Task.FromResult(Mapper.Map<IEnumerable<KegModel>>(kegsDto));
        }

        public Task<ResourceCreationResult<KegModel, int>> CreateAsync(KegModel resource, IRequestContext context, CancellationToken cancellation)
        {
            resource.Quantity = KegModel.FullQuantity;
            var resultId = _kegRepository.Save(Mapper.Map<Keg>(resource));
            var newKegDto = _kegRepository.Get(resultId);
            var keg = Mapper.Map<KegModel>(newKegDto);
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
