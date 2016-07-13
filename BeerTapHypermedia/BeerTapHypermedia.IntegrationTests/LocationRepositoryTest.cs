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
    public class LocationRepositoryTest : IDisposable
    {
        private readonly IWindsorContainer _container;
        private readonly ILocationRepository _sut;


        public LocationRepositoryTest()
        {
            _container = new WindsorContainer();
            _container.Register(Component.For<ILocationRepository>().ImplementedBy<LocationRepositoryMock>().LifestyleSingleton());
            _sut = _container.Resolve<ILocationRepository>();
        }

        [Fact]
        public void LocationRepositoryAdd()
         {
            //arrange
            var dto = new LocationDto() { City = "Vancouver", Country = "Canada" };
            //act
            var resultId = _sut.Save(dto);
            var loc = _sut.Get(resultId);
            //assert to make sure it will return Id
            loc.Id.ShouldBeEquivalentTo(resultId);
         }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}
