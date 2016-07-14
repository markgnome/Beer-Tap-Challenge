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
    public class OfficeKegRepositoryTest : IDisposable
    {
        private readonly IWindsorContainer _container;
        private readonly IOfficeKegRepository _sut;
        private readonly IKegRepository _kegRepository;

        public OfficeKegRepositoryTest()
        {
            _container = new WindsorContainer();
            _container.Install(new DataPersistanceInstaller());
            _sut = _container.Resolve<IOfficeKegRepository>();
            _kegRepository = _container.Resolve<IKegRepository>(); ;
        }

        [Fact]
        public void ChangeKeg()
         {
            //arrange
            var kegId = 1;
            var brandId = 5;
            
            //act
            _sut.Change(kegId, brandId);
            var keg = _kegRepository.Get(kegId);
            
            //assert
            keg.KegId.ShouldBeEquivalentTo(kegId);
            keg.BrandId.ShouldBeEquivalentTo(brandId);
            
        }

        [Fact]
        public void ReplaceKeg()
        {
            //arrange
            var kegId = 1;
            var quantity = 2000;
            //act
            _sut.Replace(kegId);
            var keg = _kegRepository.Get(kegId);

            //assert
            keg.KegId.ShouldBeEquivalentTo(kegId);
            keg.Quantity.ShouldBeEquivalentTo(quantity);

        }

        [Fact]
        public void PintAGlassBeerKeg()
        {
            //arrange
            var kegId = 1;
            var glassMl = 500;
            //act
            ReplaceKeg();
            _sut.Pint(kegId, glassMl);
            var keg = _kegRepository.Get(kegId);

            //assert
            keg.KegId.ShouldBeEquivalentTo(kegId);
            keg.Quantity.ShouldBeEquivalentTo(1500);

        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}
