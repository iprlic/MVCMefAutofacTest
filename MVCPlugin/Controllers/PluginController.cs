using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPlugin.Models;

namespace MVCPlugin.Controllers
{
    [Export(typeof(IController))]
    [ExportMetadata("ControllerName", "Plugin")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PluginController : Controller
    {
        
        public ActionResult Index()
        {
            return View("Test", new TestModel());
        }
    }
}
