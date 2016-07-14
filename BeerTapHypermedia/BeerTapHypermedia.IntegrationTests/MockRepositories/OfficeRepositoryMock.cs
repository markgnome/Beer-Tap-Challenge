using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Http.OData.Formatter;
using BeerTapHypermedia.DataAccess;
using BeerTapHypermedia.DataAccess.Dtos;

namespace BeerTapHypermedia.IntegrationTests.MockRepositories
{
    public class OfficeRepositoryMock : IOfficeRepository
    {
        private List<OfficeDto> _offices;
        private List<KegDto> _kegs;
        private List<OfficeKegDto> _officeKegs;

        public OfficeRepositoryMock()
        {
            _offices = Offices().ToList();
            _kegs = Kegs().ToList();
            _officeKegs = OfficeKegs().ToList();
        }

        public OfficeKegDto Get(int officeId)
        {
            var office = _offices.First(o => o.Id == officeId);
            return new OfficeKegDto()
            {
                Id = officeId,
                Name = office.Name,
                Description = office.Description,
                LocationId = office.LocationId,
                Kegs = _kegs.Where(k => k.OfficeId == officeId).ToList()
            };
        }

        public IEnumerable<OfficeKegDto> GetAll()
        {
            return _officeKegs;
        }

        public int Save(OfficeDto office)
        {
            var id = _offices.Count + 1;
            office.Id = id;
            _offices.Add(office);
            return id;
        }

        public void Update(OfficeDto office)
        {
            var officeUpdate = _offices.First(o => o.Id == office.Id);
            if (officeUpdate != null)
            {
                officeUpdate.Description = office.Description;
                officeUpdate.Name = office.Name;
                officeUpdate.LocationId = office.LocationId;
            }
        }

        public void Delete(int officeId)
        {
            var officeDelete = _offices.First(o => o.Id == officeId);
            _offices.Remove(officeDelete);
        }


        private IEnumerable<OfficeDto> Offices()
        {
            _offices = new List<OfficeDto>
            {
                new OfficeDto()
                {
                    Id = 1,
                    Name = "iQ Manila",
                    Description = "Manila Office",
                    LocationId = 1
                }
            };
            IEnumerable<OfficeDto> results = _offices;
            return results;
        }


        private IEnumerable<KegDto> Kegs()
        {
            _kegs = new List<KegDto>()
            {
                new KegDto() {KegId = 1, Quantity = 100, BrandId = 1, OfficeId = 1}
            };
            IEnumerable<KegDto> results = _kegs;
            return results;
        }

        private IEnumerable<OfficeKegDto> OfficeKegs()
        {
            var officeKegs = new List<OfficeKegDto>();
            foreach (var officeDto in Offices())
            {
                officeKegs.Add(new OfficeKegDto()
                {
                    Id = officeDto.Id,
                    Name = officeDto.Name,
                    Description = officeDto.Description,
                    LocationId = officeDto.LocationId,
                    Kegs = new List<KegDto>() { Kegs().First(k => k.OfficeId == officeDto.Id)}

                });
            }
            IEnumerable<OfficeKegDto> results = officeKegs;
            return results;
        }
    }
}
