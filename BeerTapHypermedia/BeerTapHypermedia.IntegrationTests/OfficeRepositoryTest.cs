using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using Xunit;
using BeerTapHypermedia.DataAccess;
using BeerTapHypermedia.DataAccess.Installers;
using BeerTapHypermedia.IntegrationTests.MockRepositories;
using Castle.MicroKernel.Registration;
using FluentAssertions;
using IQ.Platform.Framework.Common;
using Ploeh.AutoFixture;
using BeerTapHypermedia.DataAccess.Entities;

namespace BeerTapHypermedia.IntegrationTests
{
    public class OfficeRepositoryTest : IDisposable
    {
        private readonly IWindsorContainer _container;
        private readonly IOfficeRepository _sut;


        public OfficeRepositoryTest()
        {
            _container = new WindsorContainer();
            _container.Register(Component.For<IOfficeRepository>().ImplementedBy<OfficeRepositoryMock>().LifestyleSingleton());
            _sut = _container.Resolve<IOfficeRepository>();
        }

        [Fact]
        public void ShouldCreateNewOffice()
         {
            //arrange
            var dto = new Office() {Name = "Head Quarters", Description = "Main Office", LocationId = 1};

            //act
            var returnOfficeId = _sut.Save(dto);

            //assert
            var newCreatedOffice = _sut.Get(returnOfficeId);
            returnOfficeId.ShouldBeEquivalentTo(newCreatedOffice.Id);
         }

        [Fact]
        public void ShouldUpdateOfficeDetails()
        {
            //arrange
            var officeDto = new Office() {Id = 1, Name = "New Name", Description = "New Description", LocationId = 2};
            var getObjectOffice = _sut.Get(officeDto.Id);

            //act
            _sut.Update(officeDto);
            var updatedOffice = _sut.Get(officeDto.Id);

            //act
            updatedOffice.Id.ShouldBeEquivalentTo(officeDto.Id);
            updatedOffice.Name.ShouldBeEquivalentTo(officeDto.Name);
            updatedOffice.Description.ShouldBeEquivalentTo(officeDto.Description);
            updatedOffice.LocationId.ShouldBeEquivalentTo(officeDto.LocationId);

        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}
