using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using IQ.Foundation.Logging;

namespace BeerTapHypermedia.DataAccess.Installers
{
    public class DataPersistanceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ILocationRepository>().ImplementedBy<LocationRepository>().LifestyleSingleton());

            container.Register(
                Component.For<IDatabaseContextFactory<BeerTapContext>>().ImplementedBy<DatabaseContextFactory>().LifestyleSingleton());
        }
    }
}
