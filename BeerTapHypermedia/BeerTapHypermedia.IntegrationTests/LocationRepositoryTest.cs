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
using FluentAssertions;
namespace BeerTapHypermedia.IntegrationTests
{
    public class LocationRepositoryTest
    {

        [Fact]
        public void LocationRepositoryAdd()
        {
            var dto = new LocationDto() { City = "Vancouver", Country = "Canada" };
            using (var container = new WindsorContainer())
            {
                container.Install(new DataPersistanceInstaller());
                var sut = container.Resolve<ILocationRepository>();
                var query = sut.Get(1);
                var result = sut.Save(dto);
                result.Should().Be(1, "Identity has been inserted");
            }
        }
    }
}
