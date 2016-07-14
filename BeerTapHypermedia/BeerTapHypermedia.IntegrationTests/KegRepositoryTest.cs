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
    public class KegRepositoryTest : IDisposable
    {
        private readonly IWindsorContainer _container;
        private readonly IKegRepository _sut;


        public KegRepositoryTest()
        {
            _container = new WindsorContainer();
            _container.Register(Component.For<IDatabaseContextFactory<BeerTapContext>>().ImplementedBy<DatabaseContextFactory>().LifestyleSingleton());
            _container.Register(Component.For<IKegRepository>().ImplementedBy<KegRepository>().LifestyleSingleton());
            _sut = _container.Resolve<IKegRepository>();
        }

        [Fact]
        public void ShouldCreateNewKeg()
         {
            //arrange
            var dto = new KegDto() {BrandId = 0, OfficeId = 1, Quantity = 500};

            //act
            var returnKegId = _sut.Save(dto);

            //assert
            var kegNewly = _sut.Get(returnKegId);
            kegNewly.KegId.ShouldBeEquivalentTo(returnKegId);
         }

        [Fact]
        public void ShouldUpdateKeg()
        {
            //arrange
            var dto = new KegDto() {KegId = 1, BrandId = 1, OfficeId = 1, Quantity = 400};
         

            //act
            _sut.Update(dto);
            var keg = _sut.Get(1);

            //act
            keg.Quantity.ShouldBeEquivalentTo(dto.Quantity);

        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}
