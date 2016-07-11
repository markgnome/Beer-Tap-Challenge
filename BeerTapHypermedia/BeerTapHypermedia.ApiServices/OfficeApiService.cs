using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IQ.Platform.Framework.WebApi.Services.Security;
using BeerTapHypermedia.ApiServices.Security;
using BeerTapHypermedia.Model;
using BeerTapHypermedia.Model.Enums;
using IQ.Platform.Framework.WebApi;

namespace BeerTapHypermedia.ApiServices
{
    public class OfficeApiService : IOfficeApiService
    {

        readonly IApiUserProvider<BeerTapHypermediaApiUser> _userProvider;

        public OfficeApiService(IApiUserProvider<BeerTapHypermediaApiUser> userProvider)
        {
            if (userProvider == null)
                throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;
        }


        public Task<Office> GetAsync(string id, IRequestContext context, CancellationToken cancellation)
        {
            var offices = GetManyAsync(context, cancellation).Result;
            var office = offices.FirstOrDefault(o => o.Id == id);
            return Task.FromResult(office);
        }

        public Task<IEnumerable<Office>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            var offices = new List<Office>();

            foreach (OfficeLocation location in Enum.GetValues(typeof(OfficeLocation)))
            {
                var office = new Office
                {
                    Description = $"iQ Office {location}",
                    Id = ((int)location).ToString(),
                    Location = location,
                    Name = $"iQ {location}",
                    Kegs = new List<Keg>
                    {
                        new Keg
                        {
                            Id = "1",
                            Quantity = 18927,
                            Brand = KegBrand.BudLight,
                        }
                    }
                };
                offices.Add(office);    
            }
            IEnumerable<Office> iOffices = offices;
            return Task.FromResult(iOffices);
        }

        public Task<ResourceCreationResult<Office, string>> CreateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<Office> UpdateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ResourceOrIdentifier<Office, string> input, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
