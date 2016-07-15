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
using BeerTapHypermedia.DataAccess.Dtos;

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


        public Task<Keg> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var kegDto = _kegRepository.Get(Convert.ToInt32(id));
            var keg = Mapper.Map<Keg>(kegDto);
            return Task.FromResult(keg);
        }

        public Task<IEnumerable<Keg>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            var kegs = new List<Keg>();
            var kegsDto = _kegRepository.GetAll();
            return Task.FromResult(Mapper.Map<IEnumerable<Keg>>(kegsDto));
        }

        public Task<ResourceCreationResult<Keg, int>> CreateAsync(Keg resource, IRequestContext context, CancellationToken cancellation)
        {
            var resultId = _kegRepository.Save(Mapper.Map<KegDto>(resource));
            var newKegDto = _kegRepository.Get(resultId);
            var keg = Mapper.Map<Keg>(newKegDto);
           return Task.FromResult(new ResourceCreationResult<Keg, int>(keg));
        }

        public Task<Keg> UpdateAsync(Keg resource, IRequestContext context, CancellationToken cancellation)
        {
            var kegDto = Mapper.Map<KegDto>(resource);
            _kegRepository.Update(kegDto);
            return Task.FromResult(resource);
        }

        public Task DeleteAsync(ResourceOrIdentifier<Keg, int> input, IRequestContext context, CancellationToken cancellation)
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
