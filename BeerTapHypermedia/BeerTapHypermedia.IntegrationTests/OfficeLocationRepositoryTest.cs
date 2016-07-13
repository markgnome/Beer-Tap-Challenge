using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using Xunit;
using BeerTapHypermedia.DataAccess;
using BeerTapHypermedia.DataAccess.Dtos;
using BeerTapHypermedia.DataAccess.Installers;
using BeerTapHypermedia.IntegrationTests.MockRepositories;
using Castle.MicroKernel.Registration;
using FluentAssertions;
using IQ.Platform.Framework.Common;
using Ploeh.AutoFixture;

namespace BeerTapHypermedia.IntegrationTests
{
    public class OfficeLocationRepositoryTest : IDisposable
    {
        private readonly IWindsorContainer _container;
        private readonly IOfficeRepository _sut;


        public OfficeLocationRepositoryTest()
        {
            _container = new WindsorContainer();
            _container.Install(new DataPersistanceInstaller());
            //_container.Register(Component.For<ILocationRepository>().ImplementedBy<LocationRepositoryMock>().LifestyleSingleton());
            _sut = _container.Resolve<IOfficeRepository>();
        }

        [Fact]
        public void LocationRepositoryAdd()
         {
            //arrange
            var dto = new OfficeDto() {Name = "Head Quarters", Description = "Main Office", LocationId = 1};
            //act
            //var resultId = _sut.Save(dto);
            //var loc = _sut.Get(4);
            //assert to make sure it will return Id
            //loc.Id.ShouldBeEquivalentTo(4);
            _sut.Delete(6);
            var results = _sut.GetAll();
         }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}
