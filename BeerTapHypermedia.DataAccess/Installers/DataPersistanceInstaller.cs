﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BeerTapHypermedia.DataAccess.Installers
{
    public class DataPersistanceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IKegRepository>().ImplementedBy<KegRepository>().LifestyleSingleton());

            container.Register(Component.For<IOfficeRepository>().ImplementedBy<OfficeRepository>().LifestyleSingleton());

            container.Register(Component.For<IOfficeKegRepository>().ImplementedBy<OfficeKegRepository>().LifestyleSingleton());

            container.Register(Component.For<IDatabaseContextFactory<BeerTapDbContext>>().ImplementedBy<DatabaseContextFactory>().LifestyleSingleton());
        }
    }
}
