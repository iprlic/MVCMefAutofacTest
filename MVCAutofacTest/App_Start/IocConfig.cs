using System.Web.Mvc;
using Autofac.Integration.Mef;
using Autofac.Integration.Mvc;
using Autofac;


namespace MVCAutofacTest
{
    public static class IocConfig
    {
        static public void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterComposablePartCatalog(MefConfig.Catalog);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}