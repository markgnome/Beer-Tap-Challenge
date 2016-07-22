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
using IQ.Platform.Framework.Common;

namespace BeerTapHypermedia.ApiServices
{
    public class OfficeApiService : IOfficeApiService
    {

        readonly IApiUserProvider<BeerTapHypermediaApiUser> _userProvider;
        private readonly IOfficeRepository _officeRepository;
        private readonly IKegRepository _kegRepository;
        public OfficeApiService(IApiUserProvider<BeerTapHypermediaApiUser> userProvider, IOfficeRepository officeRepository, IKegRepository kegRepository)
        {
            if (userProvider == null) throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;
            _officeRepository = officeRepository;
            _kegRepository = kegRepository;
        }


        public Task<OfficeModel> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var officeDto = _officeRepository.Get(Convert.ToInt32(id));
            var officeModel = Mapper.Map<OfficeModel>(officeDto);
            return Task.FromResult(officeModel);
        }

        public Task<IEnumerable<OfficeModel>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            var allOffices = _officeRepository.GetAll();
            var officesModel = Mapper.Map<IEnumerable<OfficeModel>>(allOffices);
            return Task.FromResult(officesModel);
        }

        public Task<ResourceCreationResult<OfficeModel, int>> CreateAsync(OfficeModel resource, IRequestContext context, CancellationToken cancellation)
        {
            var resultId = _officeRepository.Save(Mapper.Map<Office>(resource));
            var officeKegDto = _officeRepository.Get(resultId);
            var officeModel = Mapper.Map<OfficeModel>(officeKegDto);
           return Task.FromResult(new ResourceCreationResult<OfficeModel, int>(officeModel));
        }

        public Task<OfficeModel> UpdateAsync(OfficeModel resource, IRequestContext context, CancellationToken cancellation)
        {
            var officeDto = Mapper.Map<Office>(resource);
            _officeRepository.Update(officeDto);
            return Task.FromResult(resource);
        }

        public Task DeleteAsync(ResourceOrIdentifier<OfficeModel, int> input, IRequestContext context, CancellationToken cancellation)
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
