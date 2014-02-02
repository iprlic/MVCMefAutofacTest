using System;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using MVCAutofacTest.Core.PluginInterfaces;

namespace MVCAutofacTest.Core
{
    public class MefControllerFactory: DefaultControllerFactory
    {
       private readonly CompositionContainer _compositionContainer;

       public MefControllerFactory(CompositionContainer compositionContainer)
       {
           _compositionContainer = compositionContainer;
       }


       protected override Type GetControllerType(RequestContext requestContext, string controllerName)
       {
           var controllerType = base.GetControllerType(requestContext, controllerName);

           if (controllerType == null)
           {
               var controller = _compositionContainer.GetExports<IController, IControllerMetaData>().SingleOrDefault(x => x.Metadata.ControllerName.ToLowerInvariant() == controllerName.ToLowerInvariant());

               if (controller != null)
               {
                   return controller.Value.GetType();
               }
           }
           return controllerType;
       }
    }
}