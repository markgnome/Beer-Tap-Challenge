using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Http.OData.Formatter;
using BeerTapHypermedia.DataAccess;
using BeerTapHypermedia.DataAccess.Entities;

namespace BeerTapHypermedia.IntegrationTests.MockRepositories
{
    public class OfficeRepositoryMock : IOfficeRepository
    {
        private List<Office> _offices;
        private List<Keg> _kegs;
        private List<OfficeKeg> _officeKegs;

        public OfficeRepositoryMock()
        {
            _offices = Offices().ToList();
            _kegs = Kegs().ToList();
            _officeKegs = OfficeKegs().ToList();
        }

        public Office Get(int officeId)
        {
            var office = _offices.First(o => o.Id == officeId);
            return new OfficeKeg()
            {
                Id = officeId,
                Name = office.Name,
                Description = office.Description,
                LocationId = office.LocationId,
                Kegs = _kegs.Where(k => k.OfficeId == officeId).ToList()
            };
        }

        public IEnumerable<OfficeKeg> GetAll()
        {
            return _officeKegs;
        }

        public int Save(Office office)
        {
            var id = _offices.Count + 1;
            office.Id = id;
            _offices.Add(office);
            return id;
        }

        public void Update(Office office)
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


        private IEnumerable<Office> Offices()
        {
            _offices = new List<Office>
            {
                new Office()
                {
                    Id = 1,
                    Name = "iQ Manila",
                    Description = "Manila Office",
                    LocationId = 1
                }
            };
            IEnumerable<Office> results = _offices;
            return results;
        }


        private IEnumerable<Keg> Kegs()
        {
            _kegs = new List<Keg>()
            {
                new Keg() {Id = 1, Quantity = 100, BrandId = 1, OfficeId = 1}
            };
            IEnumerable<Keg> results = _kegs;
            return results;
        }

        private IEnumerable<OfficeKeg> OfficeKegs()
        {
            var officeKegs = new List<OfficeKeg>();
            foreach (var Office in Offices())
            {
                officeKegs.Add(new OfficeKeg()
                {
                    Id = Office.Id,
                    Name = Office.Name,
                    Description = Office.Description,
                    LocationId = Office.LocationId,
                    Kegs = new List<Keg>() { Kegs().First(k => k.OfficeId == Office.Id)}

                });
            }
            IEnumerable<OfficeKeg> results = officeKegs;
            return results;
        }

        Office IOfficeRepository.Get(int officeId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Office> IOfficeRepository.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
