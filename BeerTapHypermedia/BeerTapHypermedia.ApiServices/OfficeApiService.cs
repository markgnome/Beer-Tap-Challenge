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
    public class OfficeApiService : IOfficeApiService
    {

        readonly IApiUserProvider<BeerTapHypermediaApiUser> _userProvider;
        private readonly IOfficeRepository _officeRepository;
        public OfficeApiService(IApiUserProvider<BeerTapHypermediaApiUser> userProvider, IOfficeRepository officeRepository)
        {
            if (userProvider == null) throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;
            _officeRepository = officeRepository;
        }


        public Task<Office> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var officeDto = _officeRepository.Get(Convert.ToInt32(id));
            var officeModel = Mapper.Map<Office>(officeDto);
            return Task.FromResult(officeModel);
        }

        public Task<IEnumerable<Office>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            var offices = new List<Office>();
            var allOffices = _officeRepository.GetAll();
            return Task.FromResult(Mapper.Map<IEnumerable<Office>>(allOffices));
        }

        public Task<ResourceCreationResult<Office, int>> CreateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            var resultId = _officeRepository.Save(Mapper.Map<OfficeDto>(resource));
            var officeKegDto = _officeRepository.Get(resultId);
            var officeModel = Mapper.Map<Office>(officeKegDto);
           return Task.FromResult(new ResourceCreationResult<Office, int>(officeModel));
        }

        public Task<Office> UpdateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            var officeDto = Mapper.Map<OfficeDto>(resource);
            _officeRepository.Update(officeDto);
            return Task.FromResult(resource);
        }

        public Task DeleteAsync(ResourceOrIdentifier<Office, int> input, IRequestContext context, CancellationToken cancellation)
        {
            if (input.HasResource)
            {
                _officeRepository.Delete(input.Id);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
