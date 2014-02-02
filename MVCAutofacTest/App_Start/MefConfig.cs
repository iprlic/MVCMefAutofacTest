using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Reflection;
using System.Web.Mvc;
using MVCAutofacTest.Core;

namespace MVCAutofacTest
{
    public static class MefConfig
    {
        public static ComposablePartCatalog Catalog { get; private set; }

        public static void RegisterMef()
        {
            CompositionContainer container = ConfigureContainer();
            ControllerBuilder.Current.SetControllerFactory(new MefControllerFactory(container));
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new MefDependencyResolver(container);
        }

        private static CompositionContainer ConfigureContainer()
        {
            Catalog = new AggregateCatalog( 

                new AssemblyCatalog(Assembly.GetExecutingAssembly()),

                new DirectoryCatalog(PreApplicationInit.ShadowCopyFolder.FullName));

            var container = new CompositionContainer(Catalog);

            return container;
        }
    }
}