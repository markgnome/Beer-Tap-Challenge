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
    public class OfficeKegApiService : IOfficeKegApiService
    {

        readonly IApiUserProvider<BeerTapHypermediaApiUser> _userProvider;
        private readonly IOfficeKegRepository _officeKegRepository;
        private readonly IKegRepository _kegRepository;
        public OfficeKegApiService(IApiUserProvider<BeerTapHypermediaApiUser> userProvider, IOfficeKegRepository officeKegRepository, IKegRepository kegRepository)
        {
            if (userProvider == null) throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;
            _officeKegRepository = officeKegRepository;
            _kegRepository = kegRepository;
        }



        public Task<KegModel> ChangeKeg(ChangeKeg resource, IRequestContext context, CancellationToken cancellation)
        {
            _officeKegRepository.Change(resource.KegId, (int)resource.Brand);
            return Task.FromResult(Mapper.Map<KegModel>(_kegRepository.Get(resource.KegId)));
        }

        public Task<Beer> PullBeer(Pint resource, IRequestContext context, CancellationToken cancellation)
        {
            Beer beer;
            try
            {
                var kegResult = _kegRepository.Get(resource.Id);
                if (kegResult.Quantity <= resource.Volume)

                    _officeKegRepository.Pint(resource.Id, resource.Volume);
                 beer = new Beer()
                {
                    OfficeId = kegResult.OfficeId,
                    KegId = kegResult.OfficeId,
                    Volume = resource.Volume,
                    Brand = (KegBrand) kegResult.BrandId
                };
            }
            catch (Exception exception)
            {
                throw context.CreateHttpResponseException<Beer>(exception.Message, HttpStatusCode.BadRequest);

            }
            return Task.FromResult(beer);
        }


        public Task<KegModel> ReplaceKeg(ReplaceKeg resource, IRequestContext context, CancellationToken cancellation)
        {
            _kegRepository.Delete(resource.KegId);
            var kegResult = _officeKegRepository.Replace(resource.Id, (int) resource.Brand);
            return Task.FromResult(Mapper.Map<KegModel>(kegResult));
        }
    }
}
